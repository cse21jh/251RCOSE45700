using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdResistenceUpgrade : Upgrade
{
    public override string Name => "���� ���� Ȯ�� ����";
    public override string Explanation => "������ ������ Ȯ���� 5% �����մϴ�";
    public override int MaxAmount => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.ColdResistance, 0.05f);
        Debug.Log(Explanation);
    }
}
