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
    [SerializeField] GameObject curUiGlider;
    [SerializeField] ScoresApiController apiCOntrol;
    [SerializeField] TextMeshProUGUI gliderTouchdownCounterTMP;
    [SerializeField] TextMeshProUGUI cloudCounterTMP;
    [SerializeField] public TextMeshProUGUI playerNameTMP;
    [SerializeField] public TextMeshProUGUI playerNamePlaceholderTMP;
    [SerializeField] TextMeshProUGUI stageTMP;
    [SerializeField] Color uiGliderDoneColor;
    [SerializeField] Color stageDone;
    [SerializeField] Color stageTodo;
    [SerializeField] int glidersToRelease;

    public Color UiGliderDoneColor { get; set; }

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
        SetGliderCountTarget(Progress.Instance.gliderTargetCount);
        glidersToRelease = Progress.Instance.gliderTargetCount + 1;

        gliderTouchdownCounterTMP.text = Progress.Instance.GetTotalLanded().ToString();
        cloudCounterTMP.text = Progress.Instance.GetTotalClouds().ToString();
        setStageNum();

    }

    public void MarkTopUiGliderDone()
    {
        curUiGlider = GameObject.Find("glider-count-target/UI Glider " + glidersToRelease);
        curUiGlider.GetComponent<Image>().color = uiGliderDoneColor;
    }

    public void ModifyGroundedCounter(int num)
    {
        int counter = System.Convert.ToInt32(gliderTouchdownCounterTMP.text);
        counter += num;
        gliderTouchdownCounterTMP.text = counter.ToString();
    }

    public void ModifyCloudCounter(int num)
    {
        int counter = System.Convert.ToInt32(cloudCounterTMP.text);
        counter += num;
        cloudCounterTMP.text = counter.ToString();

    }

    public void SetGliderCountTarget(int num)
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

    public void ActivateGameOverUi()
    {

        if (uiGameOverGO.active == false)
        {
            uiGameOverGO.active = true;
        }
    }

    public void DeactivateGameOverUi()
    {

        if (uiGameOverGO.active == true)
        {
            uiGameOverGO.active = false;
        }
    }


    public void InitRestart()
    {
        GameFlow.Instance.InitRestart();
    }

    public void QuitToMenu()
    {
        GameFlow.Instance.QuitToMenu();
    }

    public void ModifyGlidersToRelease(int num)
    {
        glidersToRelease += num;
    }

    public void setStageNum()
    {
        stageTMP.text = "STAGE " + Progress.currentStage.ToString();
    }
}