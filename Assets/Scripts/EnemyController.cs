using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Grid grid;

    public WaveType currentWave;
    public WaveType nextWave;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyWave()
    {
        WaveType wave = currentWave;
        for (int idx = 0; idx < grid.maxCol * 4; idx++)
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
        return;
        // grid�� plants ��ȸ�ϸ� plant �ִ� ĭ�� plant �޾ƿ���
        // �� wave�� resistance value �����ͼ� �ش� Ȯ�� ���� ������ �츱�� ����. getresistance value �޾ƿ;� �ϰ�, �߰��� �ش� �� ���� �������� �״��� ����� �����ϵ��� �˰���
        // �׾����� plant���� die ���� 
    }
}
