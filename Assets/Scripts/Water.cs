using UnityEngine;

public class Water : MonoBehaviour
{
    public static int dragFactorPercent = 50;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
        playerMovementController.AddSpeedPenalty(gameObject, dragFactorPercent);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
        playerMovementController.RemoveSpeedPenalty(gameObject);
    }
}
