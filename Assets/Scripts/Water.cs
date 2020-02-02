using UnityEngine;

public class Water : MonoBehaviour
{
    public static int dragFactorPercent = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
            playerMovementController.AddSpeedPenalty(GetType(), dragFactorPercent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
            playerMovementController.RemoveSpeedPenalty(GetType());
        }
    }
}
