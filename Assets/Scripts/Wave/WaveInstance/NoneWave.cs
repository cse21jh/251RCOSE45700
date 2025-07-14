using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoneWave : Wave
{
    public override WaveType WaveType => WaveType.None;
    public override string WaveDescription => "������ �ƹ� �ϵ� �Ͼ�� ���� �� �����ϴ�..";
    public override string WaveSoundString => "Aging";
    public override int UnlockStage => 999;
}
