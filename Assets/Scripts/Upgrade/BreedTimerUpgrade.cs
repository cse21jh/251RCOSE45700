using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreedTimerUpgrade : Upgrade
{
    public override string Name => "���� �ð� ����";
    public override string Explanation => "���� ���� �ð��� 10�� �����մϴ�";
    public override int MaxAmount => 2;
    public override void OnSelectAction() 
    {
        GameManager.Instance.grid.AddBreedTimer(10);
        Debug.Log(GameManager.Instance.grid.breedTimer);
    }
}
