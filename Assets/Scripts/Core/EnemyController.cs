using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum WaveType
{
    Aging,
    Wind,
    Flood,
    Pest,
    Cold,
    HeavyRain,
    None
}

public class EnemyController : MonoBehaviour
{
    private static readonly Dictionary<WaveType, string> waveDescriptions = new()
    {
        { WaveType.Aging, "�� �Ϸ簡 �������ϴ�......" },
        { WaveType.Wind, "�ż� �ٶ��� ����Ĩ�ϴ�......" },
        { WaveType.Flood, "ȫ���� ���Ŀɴϴ�......" },
        { WaveType.Pest, "�ұ��� �����Ҹ��� �鸳�ϴ�......" },
        { WaveType.Cold, "����� �������� �ֽ��ϴ�......" },
        { WaveType.HeavyRain, "���찡 ������ �����մϴ�......" },
        { WaveType.None, "������ �ƹ� �ϵ� �Ͼ�� ���� �� �����ϴ�." }
    };

    private static readonly Dictionary<WaveType, string> waveSoundString= new()
    {
        { WaveType.Aging, "Aging" },
        { WaveType.Wind, "Wind" },
        { WaveType.Flood, "Flood" },
        { WaveType.Pest, "Pest" },
        { WaveType.Cold, "Cold" },
        { WaveType.HeavyRain, "HeavyRain" },
        { WaveType.None, "Aging" }
    };

    public Grid grid;

    private WaveType currentWave;
    private WaveType nextWave;
    private int waveUnlocked = 2;

    [SerializeField] TextMeshProUGUI nextWaveText;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = WaveType.Aging;
        nextWave = WaveType.Aging;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyWave()
    {
        WaveType wave = currentWave;
        Debug.Log("currentWave : " + currentWave);
        SoundManager.Instance.PlayEffect(waveSoundString[currentWave]);

        for (int idx = 0; idx < grid.GetMaxCol() * 4; idx++)
        {
            if (grid.plantGrid.ContainsKey(idx))
            {
                Plant plant = grid.plantGrid[idx];

                if(plant.CanResist(wave))
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
        int next = Random.Range(0, waveUnlocked);
        nextWave = (WaveType)next;
        return;
    }

    public void UnlockWave(int stage)
    {
        // wave ������ �� stage�� wave�� ������ �ٴ��� wave�� ������ �� waveUnlocked�� ���. unlock��ü�� stage ���� ����. ��, 6 ������������ �ٶ��� �߷��� 4�������� �������� ���� �� ��� �ʿ�. 
        switch (stage + 1)
        {
            case 5:
                waveUnlocked++;
                break;
            case 10:
                waveUnlocked++;
                break;
            case 15:
                waveUnlocked++;
                break;
            case 20:
                waveUnlocked++;
                break;
            case 25:
                waveUnlocked++;
                break;
        }
        return;
    }

    public void ShowNextWaveText()
    {
        nextWaveText.text = waveDescriptions[currentWave];
    }

    private void FlushNextWaveText()
    {
        nextWaveText.text = "";
    }
}
