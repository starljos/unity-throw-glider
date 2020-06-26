using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreInfo
{
    public string name;
    public int points;
    public int bonusPoints;
    public int stage;
    public int position;


    public static ScoreInfo CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ScoreInfo>(jsonString);
    }

}

