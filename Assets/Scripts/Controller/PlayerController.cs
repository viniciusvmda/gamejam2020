using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float speed = 3.0f;
    private float speed_aux;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        speed_aux = speed;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
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
        speed = speed_aux;
    }
}
