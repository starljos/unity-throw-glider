using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform earthTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            //Debug.Log("Collision with Earth");
            this.landGlider();
        }

        if (col.gameObject.tag == "Glider")
        {
            //Debug.Log("Collision with Glider");
            this.crashGlider();
            GameFlow.Instance.loose();
        }
    }

    public void releaseGlider()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    void landGlider()
    {
        GetComponent<Animator>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.transform.SetParent(earthTransform);
        Progress.Instance.modifyTotalLanded(1);
        Player.Instance.spawnGlider();
    }

    void crashGlider()
    {
        gameObject.transform.Find("glider-main").gameObject.active = false;
        gameObject.transform.Find("glider-frak").gameObject.active = true;
    }
}
