using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    public PlayerInfo[] playerInfo;

    public int scoreTemp;
    public string nameTemp;

    private void Awake()
    {
        Instance = this;

        ReadInfo();
    }
    

    public void ReadInfo()
    {
        string url = Application.streamingAssetsPath + "/villagerInfo.json";
        string json = File.ReadAllText(url);

        playerInfo = JsonHelper.FromJson<PlayerInfo>(json);

    }
    public void Saveall()
    {
        Save();
    }

    private void Save()
    {
        for (int i = 0; i < playerInfo.Length; i++)
        {
            if (scoreTemp >= playerInfo[i].Score)
            {
                SaveByLeader(i);
                break;
            }

        }

        string json = JsonHelper.ToJson(playerInfo, true);
        string url = Application.streamingAssetsPath + "/villagerInfo.json";
        File.WriteAllText(url, json);
        print("Save level stations" + json);

        Debug.Log("Salvado" + json);

    }


    public void SaveByLeader(int a)
    {
        switch (a)
        {
            case 0:
                playerInfo[a + 2].Score = playerInfo[a + 1].Score;
                playerInfo[a + 2].Name = playerInfo[a + 1].Name;

                playerInfo[a + 1].Score = playerInfo[a].Score;
                playerInfo[a + 1].Name = playerInfo[a].Name;

                playerInfo[a].Score = scoreTemp;
                playerInfo[a].Name = nameTemp;
                break;
            case 1:
                playerInfo[a + 1].Score = playerInfo[a].Score;
                playerInfo[a + 1].Name = playerInfo[a].Name;

                playerInfo[a].Score = scoreTemp;
                playerInfo[a].Name = nameTemp;
                break;
            case 2:
                playerInfo[a].Score = scoreTemp;
                playerInfo[a].Name = nameTemp;
                break;
            default:
                break;
        }
                   
        
    }

    public void ReGenInfo()
    {
        //regen infoPlayers
        playerInfo = new PlayerInfo[3];

        playerInfo[0] = new PlayerInfo(0, "-");
        playerInfo[1] = new PlayerInfo(0, "-");
        playerInfo[2] = new PlayerInfo(0, "-");

        string json = JsonHelper.ToJson(playerInfo, true);
        string url = Application.streamingAssetsPath + "/villagerInfo.json";
        File.WriteAllText(url, json);

    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

