using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{    
    public static readonly Dictionary<Type, Func<Upgrade>> UpgradeInstance = new()
    {
        { typeof(BreedTimerUpgrade), () => new BreedTimerUpgrade()},
    };

    private Dictionary<Type, int> remainUpgrade = new();
    public Type[] randomUpgrade = new Type[3];

    //public UpgradeManager()
    //{
    //    foreach (var type in UpgradeInstance.Keys)
    //    {
    //        Upgrade tmp = UpgradeInstance[type]();
    //        remainUpgrade.Add(type, tmp.MaxAmount);
    //    }
    //}

    void Start() // �ӽ÷� start���� �ǵ���
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
    }

    private void SelectUpgrade(int idx)
    {
        //3���� idx �ش��ϴ� upgrade ����
        var tmp = randomUpgrade[idx];
        if (--remainUpgrade[tmp] == 0)
            // �ش� ���׷��̵� ���� Ƚ�� ����. ���̻� ���� �� �ϵ��� ����
        UpgradeInstance[tmp]().OnSelectAction(); // ���� ���׷��̵� �۵�. �� upgrade���� �����ص�. 
    }

    public IEnumerator Upgrade()
    {
        // SetRandomUpgrade ���� ���׷��̵� 3�� ������ ����
        // UI ���ų� �ӽ� ����� ���� ���׷��̵� ����
        // ���� �� SelectUpgrade ȣ���Ͽ� ���� �۵�
        // ���� �����ϵ��� ���� �ʿ�
        yield return null;
    }
}
