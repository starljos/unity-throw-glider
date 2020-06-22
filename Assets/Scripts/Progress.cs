using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{

    [SerializeField] public int gliderTargetCount;
    [SerializeField] public int gliderCountLanded;
    [SerializeField] static int totalLanded;
    [SerializeField] static int totalClouds;
    [SerializeField] public static int difficulty = 1;
    public static int currentStage = 1;

    public static Progress Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gliderCountLanded = 0;
        SetDifficulty();
    }

    public int GetTotalLanded()
    {
        return totalLanded;
    }
    public int GetTotalClouds()
    {
        return totalClouds;
    }

    public void ModifyTotalLanded(int x)
    {
        totalLanded += x;
        UI.Instance.MarkTopUiGliderDone();
        UI.Instance.ModifyGroundedCounter(1);
        ModifyLandedTarget(1);
        // Debug.Log(totalLanded);
    }

    public void ModifyTotalClouds(int x)
    {
        totalClouds += x;
        UI.Instance.ModifyCloudCounter(1);
    }

    public void ResetProgress()
    {
        totalClouds = 0;
        totalLanded = 0;
        currentStage = 1;
    }

    public void ModifyLandedTarget(int x)
    {
        gliderCountLanded += x;
        IsStageCompleted();
    }

    public void ModifyTarget(int x)
    {
        gliderTargetCount += x;
    }

    void IsStageCompleted()
    {
        if (gliderCountLanded == gliderTargetCount)
        {
            GameFlow.Instance.Win();
        }
    }
    public void NextStageNum()
    {
        currentStage += 1;
        Debug.Log("Current Stage: " + currentStage);
    }

    public int GetStageNum()
    {
        return currentStage;
    }
    void SetDifficulty()
    {
        if (currentStage % 1 == 0)
        {
            difficulty += 1;
            GameEvents.current.DifficultyChange();
        }
    }
}