using UnityEngine;

public class Tree : MonoBehaviour
{
    public float hardness;
    public float destroySpeed;

    private void Destroy()
    {
        hardness = Mathf.Max(0, hardness - destroySpeed);
    }

    void Update()
    {
        if (hardness <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var playerActuator = other.GetComponentInChildren<PlayerToolController>();
        if (playerActuator != null && playerActuator.IsActing())
        {
            Destroy();
        }
    }
}
