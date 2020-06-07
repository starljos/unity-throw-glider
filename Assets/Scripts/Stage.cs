using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] public int gliderTargetCount;
    [SerializeField] public int gliderCountLanded;
    [SerializeField] public int stageNumber;

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

    public void modifyLandedTarget(int x)
    {
        gliderCountLanded += x;
        this.isStageCompleted();
    }

    void isStageCompleted()
    {
        if (gliderCountLanded == gliderTargetCount)
        {
            GameFlow.Instance.win();
        }
    }
    public void nextStageNum()
    {
        stageNumber += 1;
    }

    public int getStageNum()
    {
        return stageNumber;
    }

}
