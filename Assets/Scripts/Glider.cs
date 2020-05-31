using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform earthTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // gameObject.Find("glider-main").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Debug.Log("Collision with Earth");
            this.landGlider();
        }

        if (col.gameObject.tag == "Glider")
        {
            Debug.Log("Collision with Glider");
            this.crashGlider();
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
        UI.Instance.modifyGroundedCounter(1);
    }

    void crashGlider()
    {
        gameObject.transform.Find("glider-main").gameObject.active = false;
        gameObject.transform.Find("glider-frak").gameObject.active = true;
    }
}
