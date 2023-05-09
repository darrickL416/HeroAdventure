using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ShakeCinemachine : Feedback

{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineCamera;

    [SerializeField]
    [Range(0,5)]
    private float amplitude = 1, intensity = 1;

    [SerializeField]
    [Range(0,1)]
    private float duration = 0.1f;


    private CinemachineBasicMultiChannelPerlin noise;

    private void Start()
    {
        if (cinemachineCamera == null)
            cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }


    public override void CompletePreviosFeedback()
    {
        StopAllCoroutines();
        noise.m_AmplitudeGain = 0;
    }

    public override void CreateFeedback()
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        for (float i = duration; i > 0; i-=Time.deltaTime)
        {
            noise.m_AmplitudeGain = Mathf.Lerp (0,amplitude, i / duration);
            yield return null;
        }

        noise.m_AmplitudeGain = 0;
    }
}
