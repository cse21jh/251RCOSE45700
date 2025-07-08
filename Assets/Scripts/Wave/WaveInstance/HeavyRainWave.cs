using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyRainWave : Wave
{
    public override WaveType WaveType => WaveType.HeavyRain;
    public override string WaveDescription => "���찡 ������ �����մϴ�......";
    public override string WaveSoundString => "HeavyRain";
    public override int UnlockStage => 25;
}
