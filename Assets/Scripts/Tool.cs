using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public abstract void fix();
    public abstract string getName();

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
            addToolToPlayer(other.gameObject);
        }
    }

    private void addToolToPlayer(GameObject player)
    {
        PlayerToolController playerToolController = player.GetComponent<PlayerToolController>();
        playerToolController.currentTool = this;
    }

}
