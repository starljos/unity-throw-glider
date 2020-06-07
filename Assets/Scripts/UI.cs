using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;


public class UI : MonoBehaviour
{
    [SerializeField] GameObject uiGliderPrefab;
    [SerializeField] GameObject uiGameOverGO;
    [SerializeField] TextMeshProUGUI gliderTouchdownCounterTMP;
    [SerializeField] TextMeshProUGUI cloudCounterTMP;
    [SerializeField] Color uiGliderDoneColor;
    [SerializeField] Color stageDone;
    [SerializeField] Color stageTodo;
    [SerializeField] public int glidersToRelease;

    public static UI Instance { get; private set; }

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
        this.setGliderCountTarget(Stage.Instance.gliderTargetCount);
        glidersToRelease = Stage.Instance.gliderTargetCount + 1;

        gliderTouchdownCounterTMP.text = Progress.Instance.getTotalLanded().ToString();
        cloudCounterTMP.text = Progress.Instance.getTotalClouds().ToString();

                // null reference goddamnit
        // GameObject stageIndicator;
        // stageIndicator = GameObject.Find("stage-progress/stage" + Stage.Instance.getStageNum());
        // Debug.Log(stageIndicator);
        // stageIndicator.GetComponent<Image>().color = stageDone;

    }

    public void markTopUiGliderDone()
    {
        GameObject curUiGlider;
        curUiGlider = GameObject.Find("glider-count-target/UI Glider " + glidersToRelease);
        curUiGlider.GetComponent<Image>().color = uiGliderDoneColor;
    }

    public void modifyGroundedCounter(int num)
    {
        int counter = System.Convert.ToInt32(gliderTouchdownCounterTMP.text);
        counter += num;
        gliderTouchdownCounterTMP.text = counter.ToString();
    }

    public void modifyCloudCounter(int num)
    {
        int counter = System.Convert.ToInt32(cloudCounterTMP.text);
        counter += num;
        cloudCounterTMP.text = counter.ToString();

    }

    public void setGliderCountTarget(int num)
    {
        float spawnHeight = 50;

        for (int i = 0; i < num; i++)
        {
            GameObject newUiGlider;
            newUiGlider = Instantiate(uiGliderPrefab, uiGliderPrefab.transform);
            newUiGlider.transform.SetParent(uiGliderPrefab.transform.parent);
            newUiGlider.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, spawnHeight);

            newUiGlider.name = "UI Glider " + (i + 1);
            newUiGlider.active = true;
            spawnHeight += 70;

        }
    }

    public void toggleGameOverUi()
    {
        Debug.Log(uiGameOverGO.active);

        if (uiGameOverGO.active == false)
        {
            uiGameOverGO.active = true;
        }
        else
        {
            uiGameOverGO.active = false;
        }
    }
}