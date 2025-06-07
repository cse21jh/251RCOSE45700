using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalDeathResistenceUpgrade : Upgrade
{
    public override string Name => "�ڿ��� ���� Ȯ�� ����";
    public override string Explanation => "�ڿ��翡 ������ Ȯ���� 5% �����մϴ�";
    public override int MaxAmount => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.NaturalDeath, 0.05f);
        Debug.Log(Explanation);
    }
}
