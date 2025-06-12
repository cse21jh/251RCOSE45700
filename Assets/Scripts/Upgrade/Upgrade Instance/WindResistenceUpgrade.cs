using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindResistenceUpgrade : Upgrade
{
    public override string Name => "�ٶ� ���� Ȯ�� ����";
    public override string Explanation => "�ٶ��� ������ Ȯ���� 3% �����մϴ�";
    public override Sprite Icon => ResourceLoader.LoadUpgradeIcon("UpgradeIcons_7");
    public override int MaxAmount => 5;
    public override int UnlockStage => 5;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.WindResistance, 0.03f);
        Debug.Log(Explanation);
    }
}
