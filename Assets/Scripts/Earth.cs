using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour
{

    void Awake()
    {
        GameEvents.onDifficultyChange += OnSpeedUpAnimation;
    }

    void OnDestroy()
    {
        GameEvents.onDifficultyChange -= OnSpeedUpAnimation;
    }

    void OnSpeedUpAnimation()
    {

        if (gameObject != null)
        {
            var anim = gameObject.GetComponent<Animator>();
            anim.speed = Progress.difficulty;
        }


    }
}