using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentSounds : AudioPlayer
{



   [ SerializeField]

   private AudioClip hitClip = null, deathClip = null, voiceLineClip = null;





    public void PlayHitSound()
    {

        PlayClipWithvarablePitch(hitClip);

    }

   

    public void PlayDeathSound()
    {
        PlayClip(deathClip);
    }


    public void PlayVoiceSound()
    {
        PlayClipWithvarablePitch(voiceLineClip);
    }
    
    
    


}
