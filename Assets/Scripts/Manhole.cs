using UnityEngine;

public class Manhole : InteractiveTriggerElement
{
    public float growthScale;
    public float logBase;
    public int debrisAmount;
    public int debrisInflectionAmount;
    public int cleanSpeed;

    private GameObject waterObj;
    private Vector3 initialWaterScale;

    private float t = 0;
    private int initialDebris;
    private bool cleared = false;

    protected override void Start()
    {
        base.Start();
        initialDebris = debrisAmount;
        waterObj = transform.GetChild(0).gameObject;
        initialWaterScale = waterObj.transform.localScale;
    }

    void Update()
    {
        t = Mathf.Max(0, t + (debrisAmount - debrisInflectionAmount) / (float)initialDebris * Time.deltaTime);
        waterObj.transform.localScale = initialWaterScale + GetSize() * Vector3.one;
    }

    private float GetSize()
    {
        return growthScale * Mathf.Log(t + 1, logBase);
    }

    protected override void OnPlayerAction()
    {
        if (!cleared)
        {
            debrisAmount = Mathf.Max(0, debrisAmount - cleanSpeed);
            UpdateStatusText();
            if (debrisAmount == 0)
            {
                cleared = true;
                FindObjectOfType<VictoryWatcher>().OnObstacleCleared(this);
            }
        }
    }

    protected override void UpdateStatusText()
    {
        statusText.text = $"{debrisAmount}/{initialDebris}";
    }
}
