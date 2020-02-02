using UnityEngine;

public class ObstacleTree : InteractiveTriggerElement
{
    public int hardness;
    public int destroySpeed;

    private int initialHardness;

    protected override void Start()
    {
        initialHardness = hardness;
        base.Start();
    }

    void Update()
    {
        if (hardness <= 0)
        {
            FindObjectOfType<VictoryWatcher>().OnObstacleCleared(this);
            Destroy(gameObject);
        }
    }

    protected override void OnPlayerAction()
    {
        hardness = Mathf.Max(0, hardness - destroySpeed);
        UpdateStatusText();
    }

    protected override void UpdateStatusText()
    {
        statusText.text = $"{hardness}/{initialHardness}";
    }
}
