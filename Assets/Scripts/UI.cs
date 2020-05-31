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
    [SerializeField] TextMeshProUGUI gliderTouchdownCounterTMP;

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
    }

    public void modifyGroundedCounter(int num)
    {
        int counter = System.Convert.ToInt32(gliderTouchdownCounterTMP.text);
        counter += num;
        gliderTouchdownCounterTMP.text = counter.ToString();

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

            newUiGlider.active = true;
            spawnHeight += 70;

        }
    }
}
