using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxRerollCountUpgrade : Upgrade
{
    public override string Name => "���׷��̵� ���� ���� Ƚ�� ����";
    public override string Explanation => "���׷��̵� ���� ���� Ƚ���� 1ȸ �����մϴ�";
    public override int MaxAmount => 2;
    public override void OnSelectAction()
    {
        GameManager.Instance.upgradeManager.AddMaxRerollCount(1);
        Debug.Log(Explanation);
    }
}

