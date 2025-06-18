using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*public enum CompleteTraitType // ���� ����
{
    NaturalDeath,
    WindResistance,
    FloodResistance,
    PestResistance,
    ColdResistance,
    HeavyRainResistance,
    None
}*/

public enum IncompleteTraitType // �ҿ��� ����
{
    None
}



// �����̳� ���̺� �߰� �� GetResistantValue �� ���� �� Initialize Trait ���� ���׷� ��� �߰� �ʿ�.

public abstract class Plant : MonoBehaviour
{
    public string speciesname;
    protected List<GeneticTrait> traits = new List<GeneticTrait>();

    public virtual void Init(List<GeneticTrait> newTraits)
    {
        traits = newTraits;
    }

    public virtual List<GeneticTrait> GetGeneticTrait()
    {
        return traits;
    }
    protected virtual void OnMouseEnter()
    {
        UIPlantStat.Instance.ShowInfo(speciesname, traits);
    }

    protected virtual void OnMouseExit()
    {
        UIPlantStat.Instance.HideInfo();
    }

    public bool CanResist(WaveType wave) // if can't resist, Call Die()
    {
        int randomNumber = UnityEngine.Random.Range(0, 100);
        if (randomNumber <= (int)(GetResistanceValue(wave) * 100))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected float GetResistanceValue(WaveType wave)
    {
        CompleteTraitType traitType = CompleteTraitType.None;
        float defaultResistance = 0.0f;
        switch(wave)
        {
            case WaveType.Wind: traitType = CompleteTraitType.WindResistance; break;
            case WaveType.Flood: traitType = CompleteTraitType.FloodResistance; break;
            case WaveType.Pest: traitType = CompleteTraitType.PestResistance; break;
            case WaveType.Cold: traitType = CompleteTraitType.ColdResistance; break;
            case WaveType.HeavyRain: traitType = CompleteTraitType.HeavyRainResistance; break;
            case WaveType.Aging: traitType = CompleteTraitType.NaturalDeath; break;
                // Ư�� �߰��Ǹ� �߰�
        }

        foreach(GeneticTrait g in traits)
        {
            if(g.traitType == traitType)
                return g.resistance;
        }
        
        return defaultResistance /*+ GameManager.Instance.grid.GetAdditionalResistance(traitType)*/;
    }

    public void UpdateResistance(CompleteTraitType traitType, float value)
    {
        for(int i=0; i < traits.Count; i++)
        {
            if(traits[i].traitType == traitType)
            {
                traits[i] = new GeneticTrait(traitType, traits[i].resistance + value, traits[i].genetics);
            
                return;
            }
        }
        return;
    }

    /*public Vector2Int gridPosition;
    public int gridNumber;

    [SerializeField]
    protected Dictionary<CompleteTraitType, float> completeResistances = new Dictionary<CompleteTraitType, float>(); // ���� �켺 ��Ģ ������ ������ ���׷�
    
    [SerializeField]
    protected Dictionary<CompleteTraitType, int> completeGenetics= new Dictionary<CompleteTraitType, int>(); // int ���� �켺 ����

    [SerializeField]
    protected Dictionary<IncompleteTraitType, float> incompleteResistances = new Dictionary<IncompleteTraitType, float>(); // �ҿ��� �켺 ������ ���� ���׷�

    public virtual void Initialize(int gridNumber, Plant parent1, Plant parent2) // ���� event �߻� ��ų �� instanciate�ϰ� ȣ��
    {
        InitializeGridPosition(gridNumber);
        InitializeCompleteTrait(parent1.completeGenetics, parent2.completeGenetics);
        InitializeIncompleteTrait(parent1.incompleteResistances, parent2.incompleteResistances);

    }

    protected void InitializeGridPosition(int gridNum)
    {
        // grid��ȣ ���� ������ ����ؼ� grid Position �ʱ�ȭ
    }

    public virtual void InitializeCompleteTrait(Dictionary<CompleteTraitType, int> parent1, Dictionary<CompleteTraitType, int> parent2) // �켺 ������ ���⼭ ���. ���� ���׷��� ���� ��ü���� ��� �޾Ƽ� ����
    {
        foreach (CompleteTraitType trait in Enum.GetValues(typeof(CompleteTraitType)))
        {
            if (trait == CompleteTraitType.None)
                break;

            parent1.TryGetValue(trait, out int p1Count);
            parent2.TryGetValue(trait, out int p2Count);

            int allele1;
            if (p1Count == 2) // RR
            {
                allele1 = 1;
            }
            else if (p1Count == 0) // rr
            {
                allele1 = 0;
            }
            else // Rr
            {
                allele1 = UnityEngine.Random.Range(0, 2);
            }

            int allele2;
            if (p2Count == 2) // RR
            {
                allele2 = 1;
            }
            else if (p2Count == 0) // rr
            {
                allele2 = 0;
            }
            else // Rr
            {
                allele2 = UnityEngine.Random.Range(0, 2);
            }

            completeGenetics[trait] = allele1 + allele2;
        }

        // ���� ��Ģ ���� ���׷� ����� �Ĺ����� �ٸ��� ���� ��ü���� ��ӹ޾� ��� 
    }

    public virtual void InitializeIncompleteTrait(Dictionary<IncompleteTraitType, float> parent1, Dictionary<IncompleteTraitType, float> parent2)
    {
        // �ҿ��� ���� ��Ģ ���� ���׷� ��� + �Ĺ� ���� ���� �ٸ� ��� �� �ʿ�
    }

    */

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public virtual void MakeSelectedSprite()
    {

    }

    public virtual void MakeDefaultSprite()
    {

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
