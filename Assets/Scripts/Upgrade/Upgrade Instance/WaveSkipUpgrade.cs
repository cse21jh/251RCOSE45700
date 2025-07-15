using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkipUpgrade : Upgrade
{
    public override string Name => "���̺� ��ŵ Ƚ�� ����";
    public override string Explanation => "���� ���̺� ��ŵ ���� Ƚ�� +1";
    public override Sprite Icon => ResourceLoader.LoadUpgradeIcon("UpgradeIcons_17");
    public override int MaxAmount => -1;
    public override int UnlockStage => 15;
    public override void OnSelectAction()
    {
        GameManager.Instance.enemyController.AddWaveSkipCount(1);
        Debug.Log(Explanation);
    }
}