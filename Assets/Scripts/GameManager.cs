using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int TotalPoints { get { return totalPoints; } }
    public int totalPoints;

    public void ScorePoints(int pointsToAdd)
    {
        totalPoints += pointsToAdd;
        Debug.Log(totalPoints);
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
