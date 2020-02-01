using UnityEngine;

public class Follower : MonoBehaviour
{
    public float distance;
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = distance * Vector3.up;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
