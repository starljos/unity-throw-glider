using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] public int gliderTargetCount;
    [SerializeField] public int gliderCountLanded;
    [SerializeField] int stageNumber;

    public static Stage Instance { get; private set; }

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
        stageNumber = 1;
        gliderCountLanded = 0;
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
        stageNumber += 1;
    }

    public int GetStageNum()
    {
        return stageNumber;
    }

}
