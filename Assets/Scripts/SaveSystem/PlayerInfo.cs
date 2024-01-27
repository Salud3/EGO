using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerInfo
{

    public int Score;
    public string Name;

    public PlayerInfo( int Score, string name)
    {
        this.Score = Score;
        this.Name = name;
    }
    
}
