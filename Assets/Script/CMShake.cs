using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMShake : MonoBehaviour
{
    private Animator cameraAnimator;

    void Start()
    {
        cameraAnimator = GetComponent<Animator>();
        if (cameraAnimator == null)
        {
            Debug.LogError("Animator component missing from this game object");
        }
    }

    public void TriggerShake()
    {
        if (cameraAnimator != null)
        {
            cameraAnimator.SetTrigger("shake");
        }
    }
}
