using System;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public int dragFactorPercent = 20;

    public abstract bool WorksForType(Type obstacleType);

    void Start()
    {
    }

    void Update()
    {
    }

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
