using UnityEngine;

public abstract class InteractiveTriggerElement : MonoBehaviour
{
    protected abstract void OnPlayerAction();

    private void OnTriggerStay(Collider other)
    {
        var playerActuator = other.GetComponent<PlayerToolController>();
        if (playerActuator != null && playerActuator.IsActing(GetType()))
        {
            OnPlayerAction();
        }
    }
}
