using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class flashLightFeedback : Feedback
{


    [SerializeField]
    private Light2D lightTarget = null;

    [SerializeField]
    private float lightOnDelay = 0.01f, lightOffDelay = 0.01f;

    [SerializeField]
    private bool defaultState = false;


    public override void CompletePreviosFeedback()
    {
        StopAllCoroutines();
        lightTarget.enabled = false;
    }

    public override void CreateFeedback()
    {
        StartCoroutine(ToggleLightCoroutine(lightOnDelay, true, () => StartCoroutine(ToggleLightCoroutine(lightOnDelay, false))));
    }


    IEnumerator ToggleLightCoroutine(float time, bool result, Action FinishCallback = null)
    {

        yield return new WaitForSeconds(time);
        lightTarget.enabled = result;
        FinishCallback?.Invoke();

    }
}
