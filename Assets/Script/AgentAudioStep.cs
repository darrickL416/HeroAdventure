using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgentAudioStep : AudioPlayer
{
   

    [SerializeField]
    protected AudioClip stepClip;



    public void PlayStepSound()
    {
        PlayClipWithvarablePitch(stepClip);
    }
}
