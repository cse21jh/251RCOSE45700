using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindResistenceUpgrade : Upgrade
{
    public override string Name => "�ٶ� ���� Ȯ�� ����";
    public override string Explanation => "�ٶ��� ������ Ȯ���� 5% �����մϴ�";
    public override int MaxAmount => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.WindResistance, 0.05f);
        Debug.Log(Explanation);
    }
}
