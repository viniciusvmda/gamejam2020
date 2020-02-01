using UnityEngine;

public class Water : MonoBehaviour
{
    public float dragFactor = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
        playerMovementController.slowDownSpeed(dragFactor);
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMovementController playerMovementController = other.GetComponent<PlayerMovementController>();
        playerMovementController.resetSpeed();
    }
}
