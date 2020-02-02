using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryManager : MonoBehaviour
{
    public Type type;
    public RectTransform gameOverPanel;
    public Text gameOverText;

    private List<InteractiveTriggerElement> obstaclesToBeRemoved;
    private float startTimeSeconds;
    private bool victory;
    private bool defeat;

    private int totalDeafeatPoints;
    private int defeatPointCount;

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

        totalDeafeatPoints = transform.childCount;
    }

    void Update()
    {
        if (victory || defeat)
        {
            if (Input.GetButton("Cancel"))
            {
                SceneManager.LoadScene("Title");
            }
            return;
        }
    }

    public void OnObstacleCleared(InteractiveTriggerElement removedObstacle)
    {
        if (defeat)
        {
            return;
        }
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
            gameOverPanel.gameObject.SetActive(true);
            gameOverText.text = $"Você venceu em {GetTimeElapsedText(":D")}";
        }
    }

    public void IncrementFloodedCounter()
    {
        if (victory)
        {
            return;
        }
        defeatPointCount += 1;
        if (defeatPointCount == totalDeafeatPoints)
        {
            defeat = true;
            gameOverPanel.gameObject.SetActive(true);
            gameOverText.text = $"Você perdeu em {GetTimeElapsedText(":(")}";
        }
    }

    private string GetTimeElapsedText(string face)
    {
        float victoryAt = Time.realtimeSinceStartup - startTimeSeconds;
        return $"{ string.Format("{0:0.00}", victoryAt)}segundos {face}\n\nPressione <ESC> para reiniciar";
    }

    public void DecrementFloodedCounter()
    {
        defeatPointCount -= 1;
    }

    public enum Type
    {
        ALL_OBSTACLES_CLEARED,
        ALL_MANHOLES_CLEARED
    }
}
