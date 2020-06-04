using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Glider CurrentGlider;
    public GameObject gliderPrefab;
    public bool isGliderReady;

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
            UI.Instance.markTopUiGliderDone();
            StartCoroutine(SpawnGliderAfterDelay(1));
        }
    }

    IEnumerator SpawnGliderAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.spawnGlider();
    }

    void spawnGlider()
    {
        GameObject newGlider;
        newGlider = Instantiate(gliderPrefab);
        newGlider.transform.SetParent(gameObject.transform);
        CurrentGlider = newGlider.GetComponent<Glider>();
        newGlider.active = true;
        isGliderReady = true;

    }
}
