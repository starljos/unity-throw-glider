using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] public static int totalLanded;
    [SerializeField] public static int totalClouds;

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

    public int getTotalLanded()
    {
        return totalLanded;
    }

    public void modifyTotalLanded(int x)
    {
        totalLanded += x;
        UI.Instance.markTopUiGliderDone();
        UI.Instance.modifyGroundedCounter(1);
        Stage.Instance.modifyLandedTarget(1);
        Debug.Log(totalLanded);
    }
}
