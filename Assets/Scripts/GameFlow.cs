using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    public static GameFlow Instance { get; private set; }
    [SerializeField] bool isGameOver;

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

        if (Progress.currentStage == null)
        {
            Progress.currentStage = 1;
        }
    }

    public void Win()
    {
        Debug.Log("Stage Won");
        Camera.Instance.moveCameraOut();
        //InitNextStage();
        StartCoroutine(LoadSceneAfterDelay(1));
    }

    public void Loose()
    {
        if (!isGameOver)
        {
            Debug.Log("Stage Lost");
            UI.Instance.ActivateGameOverUi();
            isGameOver = true;
        }
    }

    public void InitNextStage()
    {
        isGameOver = false;
        Progress.Instance.NextStageNum();

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RestartScene()
    {

        Camera.Instance.moveCameraOut();
        //InitNextStage();
        StartCoroutine(RestartSceneAfterDelay(1));

        isGameOver = false;
    }
    public void RestartFirstStage()
    {
        Progress.Instance.ResetProgress();
        SceneManager.LoadScene(1);
        isGameOver = false;
    }

    public void InitRestart()
    {
        UI.Instance.DeactivateGameOverUi();
        StartCoroutine(RestartSceneAfterDelay(1));
    }

    public void Quit()
    {
        Application.Quit();
        
    }

    public void QuitToMenu()
    {
        StartCoroutine(QuitToMenuAfterDelay(1));
        
    }

    IEnumerator LoadSceneAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        InitNextStage();
    }

    IEnumerator RestartSceneAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        RestartFirstStage();
    }
    IEnumerator QuitToMenuAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }
}