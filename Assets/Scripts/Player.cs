using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Glider CurrentGlider;
    public GameObject gliderPrefab;
    public bool isGliderReady;

    public static Player Instance { get; private set; }

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
        SpawnGlider();
    }

    void Update()
    {
        if (isGliderReady && Input.GetKeyDown("space"))
        {
            CurrentGlider.ReleaseGlider();
            isGliderReady = false;

            UI.Instance.ModifyGlidersToRelease(-1);
        }
    }

    IEnumerator SpawnGliderAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SpawnGlider();
    }

    public void SpawnGlider()
    {
        GameObject newGlider;
        newGlider = Instantiate(gliderPrefab);
        newGlider.transform.SetParent(gameObject.transform);
        CurrentGlider = newGlider.GetComponent<Glider>();
        newGlider.active = true;
        isGliderReady = true;

    }
}
