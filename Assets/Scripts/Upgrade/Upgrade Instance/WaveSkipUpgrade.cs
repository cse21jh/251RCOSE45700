using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSkipUpgrade : Upgrade
{
    public override string Name => "���̺� ��ŵ Ƚ�� ����";
    public override string Explanation => "���� ���̺� ��ŵ ���� Ƚ�� +1";
    public override int MaxAmount => -1;
    public override void OnSelectAction()
    {
        GameManager.Instance.enemyController.SetNextWave();
        Debug.Log(Explanation);
    }
}