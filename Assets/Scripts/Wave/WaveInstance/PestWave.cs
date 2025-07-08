using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestWave : Wave
{
    public override WaveType WaveType => WaveType.Pest;
    public override string WaveDescription => "�ұ��� �����Ҹ��� �鸳�ϴ�......";
    public override string WaveSoundString => "Pest";
    public override int UnlockStage => 15;
}
