using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // TODO make with events
    public static Camera Instance { get; private set; }
    private Animator anim;

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
        anim = gameObject.GetComponent<Animator>();
    }

    public void moveCameraOut()
    {
        anim.Play("camera-out");
    }
}