using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Glider CurrentGlider;
    public GameObject gliderPrefab;
    // Start is called before the first frame update
    void Start()
    {
        this.spawnGlider();
    }

    // Update is called once per frame
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
        Debug.Log("SPAWNED");

    }
}
