using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int TotalPoints { get { return totalPoints; } }
    public int totalPoints;
    public GameObject panel;

    public void ScorePoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        Debug.Log(totalPoints);

        if (totalPoints >= 100)
        {
            Time.timeScale = 0f;
            ActivatePanel();
        }
    }

    public void SubtractPoints(int pointsToSubtract)
    {
        totalPoints -= pointsToSubtract;
        Debug.Log(totalPoints);
    }

    private void Awake()
    {
        Instance = this;
    }

    void ActivatePanel()
    {
        if(panel != null)
        {
            panel.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
