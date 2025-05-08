using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        GameObject obj1 = null;
        GameObject obj2 = null;

        Debug.Log("40�� ����.");
        float startTime = Time.time;
        float endTime = startTime + 40.0f;

        while (Time.time < endTime)
        {
            if (Input.GetMouseButtonDown(0)) // �ϵ��� ���� ����. ��Ҵ� �̹� ������ �ϵ��� Ŭ���ϸ� ���. 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // ����� �ݶ��̴� component �־�� Ȯ�� ����. ���� grid ��ǥ ��� �Ǹ� ���� ����.
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    GameObject clickedObject = hit.collider.gameObject;
                    Pea clickedPea = clickedObject.GetComponent<Pea>();

                    if (clickedPea != null)
                    {
                        if(obj1 == clickedObject)
                        {
                            Debug.Log("�θ� 1 ���� ���");
                            obj1 = null;
                        }
                        else if(obj2 == clickedObject)
                        {
                            Debug.Log("�θ� 2 ���� ���");
                            obj2 = null;
                        }
                        else if(obj1 == null)
                        {
                            Debug.Log("�θ� 1 ����");
                            obj1 = clickedObject;
                        }
                        else if(obj2 == null)
                        {
                            Debug.Log("�θ� 2 ����");
                            obj2 = clickedObject;
                        }
                        else
                        {
                            Debug.Log("�̹� �� �θ� ��� ���õ� ����");
                        }
                    }
                    else
                    {
                        Debug.Log("���� �������ּ���");
                    }
                }
            }


            if (Input.GetKeyDown(KeyCode.B))
            {
                if (obj1 != null && obj2 != null) // ���� ��ư ������ ���� ����
                {
                    Pea parent1 = obj1.GetComponent<Pea>();
                    Pea parent2 = obj2.GetComponent<Pea>();
                    //�ڽ� �ϵ��� ���� ��� �� Instantiate
                    List<GeneticTrait> childTrait = Breed(parent1.GetGeneticTrait(), parent2.GetGeneticTrait());
                    GameObject childObj = Instantiate(peaPrefab);
                    Pea child = childObj.GetComponent<Pea>();
                    if(child != null)
                    {
                        child.Init(childTrait);
                        plants.Add(child);
                        Debug.Log("�ڽ� ���� ����");
                        obj1 = null;
                        obj2 = null;
                        Debug.Log("�θ� ���� �ʱ�ȭ");
                    }
                    else
                    {
                        Debug.Log("�ڽ� ������ ���� �߻�");
                        Destroy(childObj);
                    }
                    
                }
                else
                {
                    Debug.Log("���� �� ���� ��� �������� �ʾҽ��ϴ�");
                }
            }

            yield return null;
        }


        Debug.Log("���� ������ ����");
        //Grid ���ε�

        yield return null;
    }    

    private void ShowPlantsOnGrid()
    {

    }

    private List<GeneticTrait> Breed(List<GeneticTrait> parent1, List<GeneticTrait> parent2)
    {
        List<GeneticTrait> childTrait = new List<GeneticTrait>();

        foreach (CompleteTraitType trait in System.Enum.GetValues(typeof(CompleteTraitType)))
        {
            if (trait == CompleteTraitType.None)
                break;

            int p1Trait;
            int p2Trait;
            
            int childGenetic = 0;

            int traitNotInParent = 0;

            if(parent1.Any(t=>t.traitType == trait))
            {
                p1Trait = parent1.First(t => t.traitType == trait).genetics;
            }
            else
            {
                p1Trait = 2;
                traitNotInParent += 1;
            }

            if (parent2.Any(t => t.traitType == trait))
            {
                p2Trait = parent2.First(t => t.traitType == trait).genetics;
            }
            else
            {
                p2Trait = 2;
                traitNotInParent += 1;
            }

            if (traitNotInParent == 2)
                continue;

            switch (p1Trait)
            {
                case 2: childGenetic += 1; break;
                case 1: childGenetic += (Random.Range(0, 2)); break;
                default: break;
            }

            switch (p2Trait)
            {
                case 2: childGenetic += 1; break;
                case 1: childGenetic += (Random.Range(0, 2)); break;
                default: break;
            }

            float resistance = 0f;
            switch (childGenetic)
            {
                case 0: resistance = 0.9f; break;
                default: resistance = 0.7f; break;
            }
            childTrait.Add(new GeneticTrait(trait, resistance, childGenetic));
        }


        return childTrait;  
    }
}
