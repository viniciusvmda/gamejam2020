using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tool : MonoBehaviour
{
    public static int dragFactorPercent;

    public abstract bool WorksForType(Type obstacleType);
    public abstract void ConfigureUIText(Text text);

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonUp("Jump"))
        {
            AddToolToPlayer(other.gameObject);
        }
    }

    private void AddToolToPlayer(GameObject player)
    {
        var playerToolController = player.GetComponent<PlayerToolController>();
        playerToolController.SetCurrentTool(this);
    }
}
