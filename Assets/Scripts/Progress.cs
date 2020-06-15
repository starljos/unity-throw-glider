using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    [SerializeField] static int totalLanded;
    [SerializeField] static int totalClouds;

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
        Stage.Instance.ModifyLandedTarget(1);
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
        
    }
}
