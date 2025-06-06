using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{    
    public static readonly Dictionary<Type, Func<Upgrade>> UpgradeInstance = new()
    {
        { typeof(BreedTimerUpgrade), () => new BreedTimerUpgrade()},
    };

    private Dictionary<Type, int> remainUpgrade = new();
    public Type[] randomUpgrade = new Type[3];

    private float upgradeTimer = 30.0f;
    private int rerollCount = 3;

    void Start() 
    {
        InitUpgrade();
    }

    private void InitUpgrade()
    {
        foreach (var type in UpgradeInstance.Keys)
        {
            Upgrade tmp = UpgradeInstance[type]();
            remainUpgrade.Add(type, tmp.MaxAmount);
        }
    }

    private void SetRandomUpgrade()
    {
        // randomUpgrade�� 3�� �����ϰ� �����ϱ� remainUpgrade 0�̸� �� ��������. reroll�ϸ� �ش� �Լ� ��ȣ��?
        List<Type> availableUpgrades = remainUpgrade.Where(kvp => kvp.Value > 0).Select(kvp => kvp.Key).ToList();
        for (int i = 0; i < randomUpgrade.Length; i++)
            randomUpgrade[i] = null; 

        
        for(int i = 0; i<randomUpgrade.Length; i++)
        {
            if (availableUpgrades.Count == 0)
                break;

            int randomIndex = UnityEngine.Random.Range(0, availableUpgrades.Count);
            randomUpgrade[i] = availableUpgrades[randomIndex];
            availableUpgrades.RemoveAt(randomIndex);
        }

        for (int i = 0; i < randomUpgrade.Length; i++)
        {
            if (randomUpgrade[i] != null)
            {
                Debug.Log($"Random Upgrade Slot {i}: {randomUpgrade[i].Name}");
            }
            else
            {
                Debug.Log($"Random Upgrade Slot {i}: Empty");
            }
        }

    }

    private void SelectUpgrade(int idx)
    {
        var tmp = randomUpgrade[idx];
        if (tmp == null)
        { 
            Debug.Log("���׷��̵� ���� X");
            return;
        }
        remainUpgrade[tmp]--;            
        UpgradeInstance[tmp]().OnSelectAction(); // ���� ���׷��̵� �۵�. �� upgrade���� �����ص�. 
        Debug.Log($"���׷��̵� : {UpgradeInstance[tmp]().Name}");
    }

    public IEnumerator UpgradePhase()
    {
        Debug.Log("���׷��̵� ������ ����");
        
        SetRandomUpgrade();
        bool select = false;
        

        float startTime = Time.time;
        float endTime = startTime + upgradeTimer;

        while (!select && (Time.time < endTime))
        {
            // �ӽ÷� 1,2,3 ��ư ���� �� �ǵ��� ����
            // UI ��� ���� �����ϵ��� ���� �ʿ�
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectUpgrade(0);
                select = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectUpgrade(1);
                select = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectUpgrade(2);
                select = true;
            }
            
            // �ӽ� ���� ���.
            if(Input.GetKeyDown(KeyCode.R) && rerollCount > 0)
            {
                SetRandomUpgrade();
                rerollCount--;
            }
            yield return null;
        }

        Debug.Log("���׷��̵� ������ ����");
        yield return null;
    }

}
