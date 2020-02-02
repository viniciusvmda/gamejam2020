using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWatcher : MonoBehaviour
{
    public Type type;
    public bool victory;
    public float victoryAt;
    public RectTransform gameOverPanel;
    public Text gameOverText;

    private List<InteractiveTriggerElement> obstaclesToBeRemoved;
    private float startTimeSeconds;

    void Start()
    {
        startTimeSeconds = Time.realtimeSinceStartup;
        obstaclesToBeRemoved = new List<InteractiveTriggerElement>();
        foreach (var o in FindObjectsOfType<InteractiveTriggerElement>())
        {
            if (o.enabled)
            {
                obstaclesToBeRemoved.Add(o);
            }
        }
    }
    
    public void OnObstacleCleared(InteractiveTriggerElement removedObstacle)
    {
        obstaclesToBeRemoved.Remove(removedObstacle);
        if (type == Type.ALL_OBSTACLES_CLEARED)
        {
            victory |= obstaclesToBeRemoved.Count == 0;
        }
        else if (type == Type.ALL_MANHOLES_CLEARED)
        {
            bool manholePresent = false;
            for (int i = 0; !manholePresent && i < obstaclesToBeRemoved.Count; i += 1)
            {
                manholePresent |= obstaclesToBeRemoved[i].GetType() == typeof(Manhole);
            }
            victory = !manholePresent;
        }

        if (victory)
        {
            victoryAt = Time.realtimeSinceStartup - startTimeSeconds;
            gameOverPanel.gameObject.SetActive(true);
            gameOverText.text = $"Voce venceu!\r\n{string.Format("{0:0.00}", victoryAt)} segundos";
        }
    }

    public enum Type
    {
        ALL_OBSTACLES_CLEARED,
        ALL_MANHOLES_CLEARED
    }
}
