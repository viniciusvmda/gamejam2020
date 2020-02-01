using System;

public class Axe : Tool
{
    public override bool WorksForType(Type obstacleType)
    {
        return obstacleType == typeof(ObstacleTree);
    }
}