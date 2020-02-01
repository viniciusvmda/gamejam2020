using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{ 
    public float speed = 3.0f;
    private CharacterController characterController;
    private float initialSpeed;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        initialSpeed = speed;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }

    public void slowDownSpeed(float factor)
    {
        speed *= (1 - factor);
    }

    public void resetSpeed()
    {
        speed = initialSpeed;
    }
}
