using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Glider CurrentGlider;
    public GameObject gliderPrefab;
    
    void Start()
    {
        this.spawnGlider();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CurrentGlider.releaseGlider();
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

    }
}
