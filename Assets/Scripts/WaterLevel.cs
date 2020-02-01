using System;
using UnityEngine;

public class WaterLevel : MonoBehaviour
{
    public float riseSpeed;
    public float level;

    private Vector3 positionAtStart;

    void Start()
    {
        positionAtStart = transform.position;
    }
    
    void Update()
    {
        level += riseSpeed / Time.deltaTime;
        transform.position = positionAtStart + level * Vector3.forward;
    }

    public void Drain(float minHeight, float value)
    {
        if (positionAtStart.z + level >= minHeight)
        {
            Debug.Log("drain " + value);
            level = Mathf.Max(minHeight, level - value);
        }
    }
}
