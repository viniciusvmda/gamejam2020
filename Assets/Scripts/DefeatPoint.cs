using UnityEngine;

public class DefeatPoint : MonoBehaviour
{
    int flooded = 0;

    private VictoryManager victoryManager;

    void Start()
    {
        victoryManager = FindObjectOfType<VictoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (flooded == 0)
        {
            victoryManager.IncrementFloodedCounter();
        }
        flooded += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        flooded -= 1;
        if (flooded == 0)
        {
            victoryManager.DecrementFloodedCounter();
        }
    }
}
