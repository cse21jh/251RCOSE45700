using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    public Grid grid;

    private static readonly List<Wave> unlockedWave = new List<Wave>();

    private Wave lastWave;
    private Wave currentWave;
    private Wave nextWave;

    private Wave noneWave;

    [SerializeField] TextMeshProUGUI nextWaveText;

    // Start is called before the first frame update
    void Start()
    {
        unlockedWave.Add(new AgingWave());
        noneWave = new NoneWave();
        lastWave = unlockedWave[0];
        currentWave = unlockedWave[0];
        nextWave = unlockedWave[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyWave()
    {
        Wave wave = currentWave;
        Debug.Log("currentWave : " + currentWave);
        SoundManager.Instance.PlayEffect(wave.WaveSoundString);

        if (currentWave != noneWave)
        {
            for (int idx = 0; idx < grid.GetMaxCol() * 4; idx++)
            {
                if (grid.plantGrid.ContainsKey(idx))
                {
                    Plant plant = grid.plantGrid[idx];

                    if (plant.CanResist(wave.WaveType))
                    {
                        Debug.Log(idx + "��° �Ĺ��� ���̺긦 ������ϴ�");
                    }
                    else
                    {
                        Debug.Log(idx + "��° �Ĺ��� �׾����ϴ�");
                        plant.DieWithAnimation();
                    }

                }
            }
        }
        else
            Debug.Log("������ �ƹ��ϵ� �Ͼ�� �ʾҽ��ϴ�");
        SetNextWave();
        FlushNextWaveText();
        return;
    }

    public void SetNextWave()
    {
        lastWave = currentWave;
        currentWave = nextWave;
        int next = Random.Range(0, unlockedWave.Count);
        nextWave = unlockedWave[next];
        return;
    }

    public void WaveSkip()
    {
        currentWave = noneWave;
        ShowNextWaveText();
        return;
    }

    public bool IsLastWaveNone()
    {
        if (lastWave == noneWave)
            return true;
        else
            return false;
    }

    public void UnlockWave(int stage)
    {
        // wave ������ �� stage�� wave�� ������ �ٴ��� wave�� ������ �� waveUnlocked�� ���. unlock��ü�� stage ���� ����. ��, 6 ������������ �ٶ��� �߷��� 4�������� �������� ���� �� ��� �ʿ�. 
        switch (stage + 1)
        {
            case 5:
                unlockedWave.Add(new WindWave());
                break;
            case 10:
                unlockedWave.Add(new FloodWave());
                break;
            case 15:
                unlockedWave.Add(new PestWave());
                break;
            case 20:
                unlockedWave.Add(new ColdWave());
                break;
            case 25:
                unlockedWave.Add(new HeavyRainWave());
                break;
        }
        return;
    }

    public void ShowNextWaveText()
    {
        nextWaveText.text = currentWave.WaveDescription;
    }

    private void FlushNextWaveText()
    {
        nextWaveText.text = "";
    }
}
