using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pea : Plant
{
    public override void Init(List<GeneticTrait> newTraits)
    {
        traits = newTraits;
    }

    public override List<GeneticTrait> GetGeneticTrait()
    {
        return traits;
    }
    /*public override void Initialize(int gridNumber, Plant parent1, Plant parent2)
    {
        base.Initialize(gridNumber, parent1, parent2);
    }

    public override void InitializeCompleteTrait(Dictionary<CompleteTraitType, int> parent1, Dictionary<CompleteTraitType, int> parent2)
    {
        base.InitializeCompleteTrait(parent1, parent2);

        foreach (CompleteTraitType trait in Enum.GetValues(typeof(CompleteTraitType)))
        {
            if (trait == CompleteTraitType.None)
                break;
            if (completeGenetics[trait] == 0)
                completeResistances[trait] = 0.9f;
            else
                completeResistances[trait] = 0.5f;
        }

        // ���׷� ��� �� ���� �ʿ�. ������ �����ϰ� ���� �����ϸ� 0.9 ���׷� ��������
    }

    public override void InitializeIncompleteTrait(Dictionary<IncompleteTraitType, float> parent1, Dictionary<IncompleteTraitType, float> parent2)
    {
        base.InitializeIncompleteTrait(parent1, parent2);
        // ���׷� ��� �� ���� �ʿ�
    }*/




    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
