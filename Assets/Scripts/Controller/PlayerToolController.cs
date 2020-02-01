using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolController : MonoBehaviour
{
    public Tool currentTool;

    void Start()
    {
        currentTool = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTool != null)
        {
            if (Input.GetButtonUp("Jump"))
            {
                currentTool.fix();
            }
            currentTool.transform.position = transform.position;
        }
        
    }

    public void dropTool()
    {
        currentTool = null;
    }
}
