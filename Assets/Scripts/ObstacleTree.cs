using UnityEngine;

public class ObstacleTree : InteractiveTriggerElement
{
    public float hardness;
    public float destroySpeed;

    protected override void OnPlayerAction()
    {
        hardness = Mathf.Max(0, hardness - destroySpeed);
    }

    void Update()
    {
        if (hardness <= 0)
        {
            Destroy(gameObject);
        }
    }
}
