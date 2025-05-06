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

public enum WaveType
{
    Aging,
    Wind,
    Flood,
    Pest,
    Cold,
    HeavyRain,
    None
}

// �����̳� ���̺� �߰� �� GetResistantValue �� ���� �� Initialize Trait ���� ���׷� ��� �߰� �ʿ�.

public abstract class Plant : MonoBehaviour
{
    protected List<GeneticTrait> traits = new List<GeneticTrait>();

    public virtual void Init(List<GeneticTrait> newTraits)
    {
        traits = newTraits;
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

    public void CanResist(WaveType wave) // if can't resist, Call Die()
    {
        int randomNumber = UnityEngine.Random.Range(0, 100);
        if(randomNumber <= (int) (GetResistanceValue(wave) * 100))
        {
            return;
        }
        else
        {
            Die();
        }
    }

    protected float GetResistanceValue(WaveType wave)
    {
        float resistance = 0f;
        switch (wave)
        {
            case WaveType.Wind: resistance = completeResistances[CompleteTraitType.WindResistance]; break;
            case WaveType.Flood: resistance = completeResistances[CompleteTraitType.FloodResistance]; break;
            case WaveType.Pest: resistance = completeResistances[CompleteTraitType.PestResistance]; break;
            case WaveType.Cold: resistance = completeResistances[CompleteTraitType.ColdResistance]; break;
            case WaveType.HeavyRain: resistance = completeResistances[CompleteTraitType.HeavyRainResistance]; break;
            case WaveType.Aging: resistance = completeResistances[CompleteTraitType.NaturalDeath]; break;
            // Ư�� �߰��Ǹ� �߰�
        }
        return resistance;

    }*/

    public void Die()
    {
        // ���̺긦 ��Ƽ�� ���ϰų�, ĭ�� �ִ� �� ���� ��?
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
