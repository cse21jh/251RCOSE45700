using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBreedCountUpgrade : Upgrade
{
    public override string Name => "���� ���� Ƚ�� ����";
    public override string Explanation => "���� ���� Ƚ���� 1ȸ �����մϴ�";
    public override int MaxAmount => 6;
    public override int UnlockStage => 10;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddMaxBreedCount(1);
        Debug.Log(Explanation);
    }
}

