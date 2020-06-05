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
        this.spawnGlider();
    }

    void Update()
    {
        if (isGliderReady && Input.GetKeyDown("space"))
        {
            CurrentGlider.releaseGlider();
            isGliderReady = false;

            UI.Instance.glidersToRelease -= 1;
        }
    }

    IEnumerator SpawnGliderAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.spawnGlider();
    }

    public void spawnGlider()
    {
        GameObject newGlider;
        newGlider = Instantiate(gliderPrefab);
        newGlider.transform.SetParent(gameObject.transform);
        CurrentGlider = newGlider.GetComponent<Glider>();
        newGlider.active = true;
        isGliderReady = true;

    }
}
