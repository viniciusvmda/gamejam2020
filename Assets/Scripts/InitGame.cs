using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public List<GameObject> objectsDisabled;

    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            foreach(GameObject o in objectsDisabled)
            {
                o.SetActive(true);
            }

            gameObject.SetActive(false);
        }

    }
}
