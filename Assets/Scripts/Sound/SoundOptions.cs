using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{

    [SerializeField] AudioMixer mixer;

    public void SetMasterVolume(int percentage) {
        // Convert percentage to 0 - -80 range
        mixer.SetFloat("MasterVolume", (percentage - 100) * 0.8f);
    }

    public void SetMusicVolume(int percentage) {
        // Convert percentage to 0 - -80 range
        mixer.SetFloat("MusicVolume", (percentage - 100) * 0.8f);
    }
    
    public void SetSFXVolume(int percentage) {
        // Convert percentage to 0 - -80 range
        mixer.SetFloat("SFXVolume", (percentage - 100) * 0.8f);
    }
}
