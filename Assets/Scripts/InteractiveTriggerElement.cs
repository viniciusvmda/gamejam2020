using UnityEngine;
using UnityEngine.UI;


public abstract class InteractiveTriggerElement : MonoBehaviour
{
    public Text statusText;

    protected virtual void Start()
    {
        UpdateStatusText();
    }

    protected abstract void OnPlayerAction();
    protected abstract void UpdateStatusText();

    private void OnTriggerStay(Collider other)
    {
        var playerActuator = other.GetComponent<PlayerToolController>();
        if (playerActuator != null && playerActuator.IsActing(GetType()))
        {
            OnPlayerAction();
        }
    }
}
