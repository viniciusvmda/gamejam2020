using System;
using UnityEngine.UI;

public class Axe : Tool
{
    public override bool WorksForType(Type obstacleType)
    {
        return obstacleType == typeof(ObstacleTree);
    }

    public override void ConfigureUIText(Text text)
    {
        text.color = new UnityEngine.Color32(0x00, 0xFF, 0x09, 0xFF);
        text.text = "Machado";
    }
}