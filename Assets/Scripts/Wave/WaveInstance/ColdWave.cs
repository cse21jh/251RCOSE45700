using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdWave : Wave
{
    public override WaveType WaveType => WaveType.Cold;
    public override string WaveDescription => "�ż� �ٶ��� ����Ĩ�ϴ�......";
    public override string WaveSoundString => "Cold";
    public override int UnlockStage => 20;
}
