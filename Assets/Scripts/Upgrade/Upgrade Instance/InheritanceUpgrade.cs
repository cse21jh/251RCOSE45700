using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceUpgrade : Upgrade
{
    public override string Name => "��� ���� Ȯ�� ����";
    public override string Explanation => "������ 1�� ��ü ���� ��, ����� ������ ���� Ȯ���� 10% �����մϴ�.";
    public override int MaxAmount => 2;
    public override void OnSelectAction()
    {
        GameManager.Instance.grid.AddAdditionalInheritance(10);
    }
}
