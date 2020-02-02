using System;
using UnityEngine.UI;

public class Shovel : Tool
{
    public override bool WorksForType(Type obstacleType)
    {
        return obstacleType == typeof(Manhole);
    }

    public override void ConfigureUIText(Text text)
    {
        text.color = new UnityEngine.Color(0xF1, 0xFF, 0x00, 0xFF);
        text.text = "Pá";
    }
}
