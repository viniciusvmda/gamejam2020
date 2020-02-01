using UnityEngine;

public class PlayerToolController : MonoBehaviour
{
    public Tool currentTool;

    void Start()
    {
        currentTool = null;
    }

    void Update()
    {
        if (currentTool != null)
        {
            if (Input.GetButtonUp("Jump"))
            {
                currentTool.Fix();
            }
        }

    }

    void LateUpdate()
    {
        if (currentTool != null)
        {
            currentTool.transform.position = transform.position;
        }
        
    }

    public void SetCurrentTool(Tool newTool)
    {
        if (newTool != null)
        {
            newTool.GetComponent<Collider>().enabled = false;
        }
        if (currentTool != null)
        {
            currentTool.GetComponent<Collider>().enabled = false; ;
        }
        currentTool = newTool;
    }

    public bool IsActing()
    {
        return Input.GetButtonUp("Jump");
    }
}
