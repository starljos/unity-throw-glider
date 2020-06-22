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

    [SerializeField] GameObject gliderModelMain;
    [SerializeField] GameObject gliderModelFrak;

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
            LandGlider();
        }

        if (col.gameObject.tag == "Glider")
        {
            //Debug.Log("Collision with Glider");
            CrashGlider();
            GameFlow.Instance.Loose();
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("trigger with " + col.gameObject.name);

        if (col.gameObject.tag == "Cloud")
        {
            col.gameObject.active = false;
            Progress.Instance.ModifyTotalClouds(1);
            GetComponent<AudioSource> ().PlayOneShot (coinPick, 1);
        
        }
    }

    public void ReleaseGlider()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        // gameObject.GetComponent<AudioSource>().Play(1);
        GetComponent<AudioSource> ().PlayOneShot (throwClip, 1);

    }

    void LandGlider()
    {
        GetComponent<Animator>().enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.transform.SetParent(earthTransform);
        Progress.Instance.ModifyTotalLanded(1);
        Player.Instance.SpawnGlider();
        GetComponent<AudioSource> ().PlayOneShot (landClip, 1);
    }

    void CrashGlider()
    {
        gliderModelMain.active = false;
        gliderModelFrak.active = true;
        GetComponent<AudioSource> ().PlayOneShot (crashClip, 1);
    }
}
