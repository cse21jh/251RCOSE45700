using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddWindPlantUpgrade : Upgrade
{
    public override string Name => "�ٶ� �Ĺ� �߰�";
    public override string Explanation => "�ٶ��� ���� �Ĺ��� �ϳ� �߰��մϴ�";
    public override int MaxAmount => -1;
    public override void OnSelectAction()
    {
        List<GeneticTrait> trait = new List<GeneticTrait>
        {
            new GeneticTrait(CompleteTraitType.WindResistance, 0.9f, 2)
        };
        GameManager.Instance.grid.AddPlant(trait);
        Debug.Log(Explanation);
    }
}
