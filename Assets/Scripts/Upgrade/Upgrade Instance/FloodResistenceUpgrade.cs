using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodResistenceUpgrade : Upgrade
{
    public override string Name => "ȫ�� ���� Ȯ�� ����";
    public override string Explanation => "ȫ���� ������ Ȯ���� 5% �����մϴ�";
    public override int MaxAmount => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.FloodResistance, 0.05f);
        Debug.Log(Explanation);
    }
}
