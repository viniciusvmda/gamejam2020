using System;

public class Shovel : Tool
{
    public override bool WorksForType(Type obstacleType)
    {
        return obstacleType == typeof(Manhole);
    }
}
