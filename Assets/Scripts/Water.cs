using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float dragFactor = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().slowDownSpeed(dragFactor);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<PlayerController>().resetSpeed();
    }
}
