using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform earthTransform;
    public AudioClip throwClip;
    public AudioClip landClip;
    public AudioClip crashClip;
    public AudioClip coinPick;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        //Debug.Log("collided with " + col.gameObject.name);

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

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("trigger with " + col.gameObject.name);

        if (col.gameObject.tag == "Cloud")
        {
            col.gameObject.active = false;
            Progress.Instance.modifyTotalClouds(1);
            GetComponent<AudioSource> ().PlayOneShot (coinPick, 1);
        
        }
    }

    public void releaseGlider()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        // gameObject.GetComponent<AudioSource>().Play(1);
        GetComponent<AudioSource> ().PlayOneShot (throwClip, 1);

    }

    void landGlider()
    {
        GetComponent<Animator>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.transform.SetParent(earthTransform);
        Progress.Instance.modifyTotalLanded(1);
        Player.Instance.spawnGlider();
        //GetComponent<AudioSource> ().Stop ();
        GetComponent<AudioSource> ().PlayOneShot (landClip, 1);
    }

    void crashGlider()
    {
        gameObject.transform.Find("glider-main").gameObject.active = false;
        gameObject.transform.Find("glider-frak").gameObject.active = true;
        GetComponent<AudioSource> ().PlayOneShot (crashClip, 1);
    }
}
