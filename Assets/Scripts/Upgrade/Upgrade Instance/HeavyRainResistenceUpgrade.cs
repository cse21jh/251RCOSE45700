using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRainResistenceUpgrade : Upgrade
{
    public override string Name => "���� ���� Ȯ�� ����";
    public override string Explanation => "���쿡 ������ Ȯ���� 3% �����մϴ�";
    public override Sprite Icon => ResourceLoader.LoadUpgradeIcon("UpgradeIcons_11");
    public override int MaxAmount => 5;
    public override int UnlockStage => 25;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalResistance(CompleteTraitType.HeavyRainResistance, 0.03f);
        Debug.Log(Explanation);
    }
}
