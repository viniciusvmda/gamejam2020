﻿using UnityEngine;

public class ManHole : InteractiveTriggerElement
{
    public float growthScale;
    public float logBase;
    public float debrisAmount;
    public float debrisInflectionAmount;
    public float cleanSpeed;

    private GameObject waterObj;
    private Vector3 initialWaterScale;

    private float t;
    private float initialDebris;

    void Start()
    {
        t = 0;
        initialDebris = debrisAmount;
        waterObj = transform.GetChild(0).gameObject;
        initialWaterScale = waterObj.transform.localScale;
    }

    void Update()
    {
        t = Mathf.Max(0, t + (debrisAmount - debrisInflectionAmount) / initialDebris * Time.deltaTime);
        waterObj.transform.localScale = initialWaterScale + GetSize() * Vector3.one;
    }

    private float GetSize()
    {
        return growthScale * Mathf.Log(t + 1, logBase);
    }

    protected override void OnPlayerAction()
    {
        debrisAmount = Mathf.Max(0, debrisAmount - cleanSpeed);
    }
}
