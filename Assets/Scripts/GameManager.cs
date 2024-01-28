using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] string nameTemp;
    public string NameTemp { get { return nameTemp; } }

    [SerializeField] int totalPoints;
    public int TotalPoints { get { return totalPoints; } }


    private void Awake()
    {
        if(Instance == null)
        {

            Instance = this;
        }else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(gameObject);

    }

    public void ScorePoints(int points)
    {
        totalPoints += points;
        
    }

    public void SubtractPoints(int points)
    {
        totalPoints -= points;
        Debug.Log(totalPoints);
    }

    public void SetName(string name)
    {
        nameTemp = name;

        SaveSystem.Instance.nameTemp = name;

    }

    public void SceneLoad(int a)
    {
        SceneManager.LoadScene(a);
    }

}
