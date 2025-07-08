using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodWave : Wave
{
    public override WaveType WaveType => WaveType.Flood;
    public override string WaveDescription => "ȫ���� ���Ŀɴϴ�......";
    public override string WaveSoundString => "Flood";
    public override int UnlockStage => 10;
}
