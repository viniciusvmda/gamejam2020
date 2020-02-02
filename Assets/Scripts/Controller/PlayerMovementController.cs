using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject body;

    private float rotationFactor = 0.5f;
    private int maxSpeedPenalty;
    private CharacterController characterController;
    private PlayerToolController toolController;
    private Vector3 moveDirection = Vector3.zero;
    private Dictionary<Type, PenaltyInfo> speedPenalties = new Dictionary<Type, PenaltyInfo>();

    void Start()
    {
        toolController = GetComponent<PlayerToolController>();
        characterController = GetComponent<CharacterController>();
        maxSpeedPenalty = Water.dragFactorPercent + Tool.dragFactorPercent;
    }

    void Update()
    {
        float currentSpeed = (100 - SumSpeedPenalty()) / 100f * speed;
        bool isWalking = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
        
        Move(currentSpeed);
        if (isWalking)
        {
            RotateBody(currentSpeed);
        }
    }

    private int SumSpeedPenalty()
    {
        int sum = 0;
        foreach (var tuple in speedPenalties)
        {
            sum += tuple.Value.penalty;
        }
        return Mathf.Min(maxSpeedPenalty, sum);
    }

    private void Move(float currentSpeed)
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (moveDirection != Vector3.zero)
        {
            RotateCharacter(moveDirection);
        }
        moveDirection *= currentSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void RotateBody(float currentSpeed)
    {
        body.transform.Rotate(currentSpeed * rotationFactor, 0, 0);
    }

    public void AddSpeedPenalty(Type key, int penaltyPercent)
    {
        if (speedPenalties.ContainsKey(key))
        {
            speedPenalties[key].count += 1;
        }
        else
        {
            speedPenalties[key] = new PenaltyInfo(1, penaltyPercent);
        }
    }

    public void RemoveSpeedPenalty(Type key)
    {
        if (speedPenalties[key].count > 1)
        {
            speedPenalties[key].count -= 1;
        }
        else
        {
            speedPenalties.Remove(key);
        }
    }

    private void RotateCharacter(Vector3 moveDirection)
    {
        float newAngle = Vector3.SignedAngle(Vector3.forward, moveDirection, Vector3.up);
        transform.rotation = Quaternion.Euler(0, newAngle, 0);
        toolController.RotateTool(moveDirection);
    }

    public class PenaltyInfo
    {
        public int count;
        public int penalty;

        public PenaltyInfo(int count, int penalty)
        {
            this.count = count;
            this.penalty = penalty;
        }
    }
}
