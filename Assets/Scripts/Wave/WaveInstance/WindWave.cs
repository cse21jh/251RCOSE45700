using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindWave : Wave
{
    public override WaveType WaveType => WaveType.Wind;
    public override string WaveDescription => "�ż� �ٶ��� ����Ĩ�ϴ�......";
    public override string WaveSoundString => "Wind";
    public override int UnlockStage => 5;
}
