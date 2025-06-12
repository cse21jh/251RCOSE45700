using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoilUpgrade : Upgrade
{
    public override string Name => "���� Ȯ��";
    public override string Explanation => "������ 4ĭ �����մϴ�";
    public override Sprite Icon => ResourceLoader.LoadUpgradeIcon("UpgradeIcons_12");
    public override int MaxAmount => 4;
    public override int UnlockStage => 1;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddSoil();
    }
}
