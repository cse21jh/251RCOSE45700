using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    public Grid grid;

    private static readonly List<Wave> unlockedWave = new List<Wave>();

    private Wave currentWave;
    private Wave nextWave;

    [SerializeField] TextMeshProUGUI nextWaveText;

    // Start is called before the first frame update
    void Start()
    {
        unlockedWave.Add(new AgingWave());
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

        for (int idx = 0; idx < grid.GetMaxCol() * 4; idx++)
        {
            if (grid.plantGrid.ContainsKey(idx))
            {
                Plant plant = grid.plantGrid[idx];

                if(plant.CanResist(wave.WaveType))
                {
                    Debug.Log(idx + "��° �Ĺ��� ���̺긦 ������ϴ�");
                }
                else
                {
                    Debug.Log(idx + "��° �Ĺ��� �׾����ϴ�");
                    grid.DestroyPlant(idx);
                }

            }
        }
        SetNextWave();
        FlushNextWaveText();
        return;
    }

    public void SetNextWave()
    {
        currentWave = nextWave;
        int next = Random.Range(0, unlockedWave.Count);
        nextWave = unlockedWave[next];
        return;
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
