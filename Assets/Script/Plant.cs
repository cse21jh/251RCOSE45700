using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CompleteTraitType // ���� ����
{
    NaturalDeath,
    WindResistance,
    FloodResistance,
    PestResistance,
    ColdResistance,
    HeavyRainResistance,
    None
}

public enum IncompleteTraitType // �ҿ��� ����
{

}

public enum WaveType
{
    Aging,
    Wind,
    Flood,
    Pest,
    Cold,
    HeavyRain,
}

public abstract class Plant : MonoBehaviour
{
    public Vector2Int gridPosition;
    public int gridNumber;

    [SerializeField]
    protected Dictionary<CompleteTraitType, float> completeResistances = new Dictionary<CompleteTraitType, float>(); // ���� �켺 ��Ģ ������ ������ ���׷�

    [SerializeField]
    protected Dictionary<IncompleteTraitType, float> IncompleteResistances = new Dictionary<IncompleteTraitType, float>(); // �ҿ��� �켺 ������ ���� ���׷�

    public virtual void Initialize(int gridNumber, Plant parent1, Plant parent2) // ���� event �߻� ��ų �� instanciate�ϰ� ȣ��
    {
        InitializeGridPosition(gridNumber);
        InitializeCompleteTrait(parent1.completeResistances, parent2.completeResistances);
        InitializeIncompleteTrait(parent1.IncompleteResistances, parent2.IncompleteResistances);

    }

    protected void InitializeGridPosition(int gridNum)
    {
        // grid��ȣ ���� ������ ����ؼ� grid Position �ʱ�ȭ
    }

    public virtual void InitializeCompleteTrait(Dictionary<CompleteTraitType, float> parent1, Dictionary<CompleteTraitType, float> parent2)
    {
        // ���� ��Ģ ���� ���׷� ��� + �Ĺ� ���� ���� �ٸ� ��� �� �ʿ�
    }

    public virtual void InitializeIncompleteTrait(Dictionary<IncompleteTraitType, float> parent1, Dictionary<IncompleteTraitType, float> parent2)
    {
        // �ҿ��� ���� ��Ģ ���� ���׷� ��� + �Ĺ� ���� ���� �ٸ� ��� �� �ʿ�
    }

    public void CanResist(WaveType wave)
    {
        // ���̺� ���� ���� Ư�� ���� ��ƿ Ȯ�� ���

        int randomNumber = Random.Range(0, 100);
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
        //wave ���� ��ƿ Ȯ�� ��ȯ����...�� �ϰ� ������ enum�� �߰��ص� �˾Ƽ� �߰��ǵ��� ����� ������...
        return 0;
    }

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
