
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoresApiController : MonoBehaviour
{

    [SerializeField] GameObject rowPrefab;
    [SerializeField] public TextMeshProUGUI debugInfo;
    [SerializeField] public TextMeshProUGUI name;
    [SerializeField] public TextMeshProUGUI position;
    [SerializeField] public TextMeshProUGUI points;

    private readonly string getRecordUrl = "https://dev81817.service-now.com/api/x_84446_unityglide/unityscores/get_top";
    private readonly string getAllUrl = "https://dev81817.service-now.com/api/x_84446_unityglide/unityscores/get_all";
    private readonly string postScoreUrl = "https://dev81817.service-now.com/api/x_84446_unityglide/unityscores/post_score";
    //private readonly string nextMazdaURL = "https://dev81817.service-now.com//api/x_84446_advertrack/advert/getnextmazda/";
    private string currentMazdaSysId = "";

    private void Start()
    {

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(GetRecord(getAllUrl));
        }

    }

    public void PostScore()
    {

        StartCoroutine(PostScoreRequest());
    }


    IEnumerator PostScoreRequest()
    {


        var score = new ScoreInfo
        {
            name = "Seba",
            points = Progress.Instance.GetTotalLanded(),
            bonusPoints = 1,
            stage = 1
        };

        // JavaScriptSerializer serializer = new JavaScriptSerializer();
        // string jsonData =  serializer.Serialize(data);

        string jsonDataString = JsonUtility.ToJson(score);
        // Debug.Log(jsonDataString);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonDataString);





        string authorization = authenticate("score_bot", "kawa");
        string endpoint = postScoreUrl;

        UnityWebRequest request = UnityWebRequest.Put(endpoint, bytes);
        request.SetRequestHeader("AUTHORIZATION", authorization);
        request.SetRequestHeader("X-HTTP-Method-Override", "PUT");
        request.SetRequestHeader("accept", "application/json; charset=UTF-8");
        request.SetRequestHeader("content-type", "application/json; charset=UTF-8");

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
            yield break;
        }
        Debug.Log(request.downloadHandler.text);

    }

    public void OnButtonRecord()
    {

        //StartCoroutine(GetRecord(nextMazdaURL + currentMazdaSysId));
    }

    string authenticate(string username, string password)
    {
        string auth = username + ":" + password;
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;
        return auth;
    }

    IEnumerator GetRecord(string endpoint)
    {

        // authenticate
        string authorization = authenticate("score_bot", "kawa");
        string ApiUrl = endpoint;

        UnityWebRequest SnWebRequest = UnityWebRequest.Get(ApiUrl);
        SnWebRequest.SetRequestHeader("AUTHORIZATION", authorization);

        yield return SnWebRequest.SendWebRequest();

        if (SnWebRequest.isNetworkError || SnWebRequest.isHttpError)
        {
            Debug.LogError(SnWebRequest.error);
            yield break;
        }

        ScoreInfo[] scores = JsonHelper.getJsonArray<ScoreInfo>(SnWebRequest.downloadHandler.text);
        // Debug.Log(scores[0].name);

        float spawnHeight = -70;

        foreach (ScoreInfo score in scores)
        {
            // create a new row
            // place values
            // push down
            // actiate
            //Debug.Log(score.name);
            name.text = score.name;
            position.text = score.position.ToString();
            points.text = score.points.ToString();

            GameObject newRow;
            newRow = Instantiate(rowPrefab, rowPrefab.transform);
            newRow.transform.SetParent(rowPrefab.transform.parent);
            newRow.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, spawnHeight);

            // newRow.name = "UI Glider " + (i + 1);
            newRow.active = true;
            spawnHeight -= 46;

        }



        // }

        //var score = ScoreInfo.CreateFromJSON(SnWebRequest.downloadHandler.text);

        debugInfo.text = SnWebRequest.downloadHandler.text;



    }
}
