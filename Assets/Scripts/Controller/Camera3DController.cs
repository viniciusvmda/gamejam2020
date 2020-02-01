using UnityEngine;

public class Camera3DController : MonoBehaviour
{
    public float distance;
    public GameObject player;
    private Vector3 offset;

    void Start()
    {
        offset = distance * Vector3.up;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
