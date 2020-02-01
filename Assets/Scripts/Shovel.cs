using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : Tool
{
    public Shovel()
    {

    }

    public override void Fix()
    {
        Debug.Log("Fix using shovel");
    }

    public override string getName()
    {
        return "Shovel";
    }
}
