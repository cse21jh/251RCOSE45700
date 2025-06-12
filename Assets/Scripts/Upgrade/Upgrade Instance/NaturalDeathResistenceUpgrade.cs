using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalDeathResistenceUpgrade : Upgrade
{
    public override string Name => "�ڿ��� ���� Ȯ�� ����";
    public override string Explanation => "�ڿ��翡 ������ Ȯ���� 3% �����մϴ�";
    public override Sprite Icon => ResourceLoader.LoadUpgradeIcon("UpgradeIcons_6");
    public override int MaxAmount => 5;
    public override int UnlockStage => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.NaturalDeath, 0.03f);
        Debug.Log(Explanation);
    }
}
