using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;


public class UI : MonoBehaviour
{
    // [SerializeField] UIMessage messagePrefab;
    // [SerializeField] UIMessagePopup messagePopupPrefab;
    //[SerializeField] RectTransform messagesRoot;
    [SerializeField] TextMeshProUGUI gliderTouchdownCounter;
    //public static TextMeshProUGUI CREW_COUNT;
    //public TextMeshProUGUI CrewCount;

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

        //gliderTouchdownCounter = 3;
        //this.modifyGroundedCounter(5);
        //gameObject.transform.Find("glider-frak").gameObject.active
    }

    public void modifyGroundedCounter(int num)
    {
        int counter = System.Convert.ToInt32(gliderTouchdownCounter.text);
        counter += num;
        gliderTouchdownCounter.text = counter.ToString();

    }

}
