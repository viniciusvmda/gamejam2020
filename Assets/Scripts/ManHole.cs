using UnityEngine;

public class ManHole : MonoBehaviour
{
    public float growthScale;
    public float logBase;
    public float cleanSpeed;
    public float debrisAmount;
    public float debrisInflectionAmount;

    public bool _debug_start_cleansing = false;

    private GameObject waterObj;
    private Vector3 initialWaterScale;
    
    private float t;
    private float initialDebris;
    
    void Start()
    {
        t = 0;
        initialDebris = debrisAmount;
        waterObj = transform.GetChild(0).gameObject;
        initialWaterScale = waterObj.transform.localScale;
    }
    
    void Update()
    {
        t += (debrisAmount - debrisInflectionAmount) / initialDebris * Time.deltaTime;
        waterObj.transform.localScale = initialWaterScale + GetSize() * Vector3.one;

        if (_debug_start_cleansing)
        {
            Debug.Log("clean");
            Clean();
        }
    }

    private float GetSize()
    {
        return growthScale * Mathf.Log(t + 1, logBase);
    }

    public void Clean()
    {
        debrisAmount = Mathf.Max(0, debrisAmount - cleanSpeed);
    }
}
