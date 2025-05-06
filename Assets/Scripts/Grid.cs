using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Grid : MonoBehaviour
{
    List<Plant> plants = new List<Plant>();
    private int maxPlantNum = 16;

    [SerializeField] private GameObject peaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InitGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitGrid()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = Instantiate(peaPrefab);
            Pea pea = obj.GetComponent<Pea>();
            List<GeneticTrait> basicTrait = new List<GeneticTrait>
            {
                new GeneticTrait(CompleteTraitType.NaturalDeath, 0.7f, 1)
            };
            pea.Init(basicTrait);
            plants.Add(pea);
        }
    }

    public IEnumerator Breeding()
    {
        //40�� ���� �Ʒ� ���� �ݺ� ���� ����

        //������ �θ� �ϵ��� �� �� ����

        //�ڽ� �ϵ��� ���� ��� �� Instantiate

        //Grid ���ε�

        yield return null;
    }    

    private void ShowPlantsOnGrid()
    {

    }
}
