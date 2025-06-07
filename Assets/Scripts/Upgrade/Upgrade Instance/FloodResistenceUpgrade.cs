using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodResistenceUpgrade : Upgrade
{
    public override string Name => "ȫ�� ���� Ȯ�� ����";
    public override string Explanation => "ȫ���� ������ Ȯ���� 3% �����մϴ�";
    public override int MaxAmount => 5;
    public override int UnlockStage => 10;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.FloodResistance, 0.03f);
        Debug.Log(Explanation);
    }
}
