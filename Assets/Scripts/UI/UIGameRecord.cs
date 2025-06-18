using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameRecord : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textStage;
    [SerializeField] private TextMeshProUGUI textPea;
    [SerializeField] private TextMeshProUGUI textBug;

    // Start is called before the first frame update
    void Start()
    {
        textStage.text = $"<sprite=0> �� \"{GameRecordHolder.maxStageReached}\"���带 ���� �½��ϴ�.";
        textPea.text = $"<sprite=8> �� \"{GameRecordHolder.TotalPeas}\"������ �ϵ����� Ű�����ϴ�.";
        textBug.text = $"<sprite=10> �� \"{GameRecordHolder.TotalBugsKilled}\"������ ������ ��ҽ��ϴ�.";
        
        //Debug.Log($"{GameRecordHolder.maxStageReached}, {GameRecordHolder.TotalPeas}, {GameRecordHolder.TotalBugsKilled}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
