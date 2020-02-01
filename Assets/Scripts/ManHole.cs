using UnityEngine;

public class ManHole : MonoBehaviour
{
    public float drainage;

    private WaterLevel waterLevel;
    
    void Start()
    {
        waterLevel = FindObjectOfType<WaterLevel>();
    }
    
    void Update()
    {
        waterLevel.Drain(transform.position.z, drainage / Time.deltaTime);
    }
}
