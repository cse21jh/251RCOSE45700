using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColdPlantUpgrade : Upgrade
{
    public override string Name => "���� �Ĺ� �߰�";
    public override string Explanation => "������ ���� �Ĺ��� �ϳ� �߰��մϴ�";
    public override int MaxAmount => -1;
    public override void OnSelectAction()
    {
        List<GeneticTrait> trait = new List<GeneticTrait>
        {
            new GeneticTrait(CompleteTraitType.ColdResistance, 0.9f, 2)
        };
        GameManager.Instance.grid.AddPlant(trait);
        Debug.Log(Explanation);
    }
}
