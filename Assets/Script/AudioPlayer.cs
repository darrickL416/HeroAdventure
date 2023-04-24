using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public abstract class AudioPlayer : MonoBehaviour
{

    [SerializeField]
    protected AudioSource audioSourse;

    [SerializeField]
    protected float pitchRandomes = 0.05f;
    protected float basePitch;

 

    private void Awake()
    {
        audioSourse = GetComponent<AudioSource>();
    }


    private void Start()
    {
        basePitch = audioSourse.pitch;
    }

    protected void PlayClipWithvarablePitch(AudioClip clip)
    {
        var randomPitch = Random.Range(pitchRandomes, pitchRandomes);
        audioSourse.pitch = basePitch + randomPitch;
        PlayClip(clip);
    }

    protected void PlayClip(AudioClip clip)
    {
        audioSourse.Stop();
        audioSourse.clip = clip;
        audioSourse.Play();
    }

    
    



   

}
