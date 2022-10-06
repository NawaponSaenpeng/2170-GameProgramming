using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;
    [SerializeField] private SoAudioClips finishAudioClips;
    [SerializeField] private SoAudioClips springAudioClips;
    [SerializeField] private SoAudioClips collectedAudioClips;
    [SerializeField] private SoAudioClips respawnObjectAudioClips;
    
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClips()); 
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClips());
    }
    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClips());
    }
    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioClips.GetAudioClips());
    }
    public void PlayFinishSound()
    {
        audioSource.PlayOneShot(finishAudioClips.GetAudioClips());
    }
    public void PlaySpringSound()
    {
        audioSource.PlayOneShot(springAudioClips.GetAudioClips());
    }
    public void PlayCollectedSound()
    {
        audioSource.PlayOneShot(collectedAudioClips.GetAudioClips());
    }
    public void PlayRespawnObjectSound()
    {
        audioSource.PlayOneShot(respawnObjectAudioClips.GetAudioClips());
    }
    
}
