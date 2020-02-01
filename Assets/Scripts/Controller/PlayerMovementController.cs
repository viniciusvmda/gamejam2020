using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 3.0f;
    private CharacterController characterController;
    private PlayerToolController toolController;

    private Vector3 moveDirection = Vector3.zero;
    private Dictionary<GameObject, int> speedPenalties = new Dictionary<GameObject, int>();

    void Start()
    {
        toolController = GetComponent<PlayerToolController>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private int SumSpeedPenalty()
    {
        int sum = 0;
        foreach (var tuple in speedPenalties)
        {
            sum += tuple.Value;
        }
        return sum;
    }

    private void Move()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        toolController.RotateTool(moveDirection);
        moveDirection *= (100 - SumSpeedPenalty()) / 100f * speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void AddSpeedPenalty(GameObject key, int penaltyPercent)
    {
        speedPenalties[key] = penaltyPercent;
    }

    public void RemoveSpeedPenalty(GameObject key)
    {
        speedPenalties.Remove(key);
    }
}
