using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LeaderBoardManager : MonoBehaviour
{
    [Header("Scores")]
    public TextMeshProUGUI firstScore;
    public TextMeshProUGUI secondScore;
    public TextMeshProUGUI thirdScore;

    [Header("Names")]
    public TextMeshProUGUI firstName;
    public TextMeshProUGUI secondName;
    public TextMeshProUGUI thirdName;

    private void Start()
    {
        firstScore.text = SaveSystem.Instance.playerInfo[0].Score.ToString("#.##");
        secondScore.text = SaveSystem.Instance.playerInfo[1].Score.ToString("#.##");
        thirdScore.text = SaveSystem.Instance.playerInfo[2].Score.ToString("#.##");
        
        firstName.text = SaveSystem.Instance.playerInfo[0].Name + " :";
        secondName.text = SaveSystem.Instance.playerInfo[1].Name + " :";
        thirdName.text = SaveSystem.Instance.playerInfo[2].Name + " :";
    }

    public void Reload()
    {
        firstScore.text = SaveSystem.Instance.playerInfo[0].Score.ToString("#.##");
        secondScore.text = SaveSystem.Instance.playerInfo[1].Score.ToString("#.##");
        thirdScore.text = SaveSystem.Instance.playerInfo[2].Score.ToString("#.##");

        firstName.text = SaveSystem.Instance.playerInfo[0].Name + " :";
        secondName.text = SaveSystem.Instance.playerInfo[1].Name + " :";
        thirdName.text = SaveSystem.Instance.playerInfo[2].Name + " :";
    }



}
