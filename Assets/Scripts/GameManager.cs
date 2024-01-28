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
            Destroy(this.gameObject);
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

        SaveSystem.Instance.Saveall();

    }

    public void SceneLoad(int a)
    {
        StartCoroutine(MusicLoader(a));
    }

    public IEnumerator MusicLoader(int sceneIndex)
    {

        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneIndex);
        AudioManager.Instance.musicSource.Stop();
        yield return new WaitForSeconds(0.1f);
        AudioManager.Instance.ChargeMusicLevel();

    }

}
