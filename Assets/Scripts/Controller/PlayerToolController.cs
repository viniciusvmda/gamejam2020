using System;
using UnityEngine;

public class PlayerToolController : MonoBehaviour
{
    public float toolOffsetLength;
    public Tool currentTool;

    private PlayerMovementController playerMovementController;
    private bool debounce = false;
    private Vector3 toolPositionOffset;

    void Start()
    {
        currentTool = null;
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        debounce = false;
        if (Input.GetButton("Fire2"))
        {
            SetCurrentTool(null);
        }
    }

    void LateUpdate()
    {
        if (currentTool != null)
        {
            currentTool.transform.position = transform.position + toolPositionOffset;
        }
    }

    public void SetCurrentTool(Tool newTool)
    {
        if (newTool != null)
        {
            newTool.enabled = false;
            newTool.GetComponent<Collider>().enabled = false;
            playerMovementController.AddSpeedPenalty(newTool.gameObject, newTool.dragFactorPercent);
        }
        if (currentTool != null)
        {
            currentTool.GetComponent<Collider>().enabled = true;
            currentTool.enabled = true;
            playerMovementController.RemoveSpeedPenalty(currentTool.gameObject);
        }
        currentTool = newTool;
    }

    public bool IsActing(Type obstacleType)
    {
        bool isActing = false;
        if (!debounce)
        {
            debounce = true;
            isActing = currentTool != null && currentTool.WorksForType(obstacleType) && Input.GetButtonUp("Jump");
        }
        return isActing;
    }

    public void RotateTool(Vector3 moveDirection)
    {
        if (currentTool != null && moveDirection != Vector3.zero)
        {
            toolPositionOffset = toolOffsetLength * moveDirection.normalized;
        }
    }
}
