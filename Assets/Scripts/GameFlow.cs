using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public static GameFlow Instance { get; private set; }
    [SerializeField] public bool isGameOver;

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
        isGameOver = false;
    }

    public void win()
    {
        Debug.Log("Stage Won");
        this.initNextStage();
    }

    public void loose()
    {
        if (!isGameOver)
        {
            Debug.Log("Stage Lost");
            UI.Instance.toggleGameOverUi();
            isGameOver = true;
        }
    }

    public void initNextStage()
    {
        Debug.Log("Starting next stage");
        isGameOver = false;
        //SceneManager.LoadScene("Throw");
        Stage.Instance.nextStageNum();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isGameOver = false;
    }
}