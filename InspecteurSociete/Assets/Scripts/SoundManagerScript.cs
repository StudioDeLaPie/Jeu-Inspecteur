using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManagerScript : MonoBehaviour
{
    public AudioClip normalButton;
    public AudioClip succesButton;
    public AudioSource sourceAudioNormalButton;
    public AudioSource sourceAudioSuccesButton;
    private void Start()
    {
        //sourceAudio = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySoundButton()
    {
        sourceAudioNormalButton.PlayOneShot(normalButton);
    }

    public void PlaySoundSuccesButton()
    {
        sourceAudioSuccesButton.PlayOneShot(succesButton);
    }
}
