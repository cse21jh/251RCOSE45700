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
        for(int i = 0; i < 2; i++)
        {
            GameObject obj = Instantiate(peaPrefab);
            Pea pea = obj.GetComponent<Pea>();
            //pea.Initialize();
            plants.Add(pea);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
