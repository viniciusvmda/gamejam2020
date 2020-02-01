using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public abstract void Fix();
    public abstract string getName();

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonUp("Jump"))
        {
            AddToolToPlayer(other.gameObject);
        }
    }

    private void AddToolToPlayer(GameObject player)
    {
        var playerToolController = player.GetComponent<PlayerToolController>();
        playerToolController.SetCurrentTool(this);
    }

}
