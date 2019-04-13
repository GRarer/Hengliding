using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    SoundManager soundManager;
    SoundOptions soundOptions;

    void Start() {
        soundManager = SoundManager.Instance();
        if (soundManager == null) {
            Debug.LogError("Sound Manager not found.");
        }
        soundOptions = SoundOptions.Instance();
        if (soundOptions == null) {
            Debug.LogError("Sound Options not found.");
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Z)) {
            soundManager.Playsfx(SoundManager.SFX.weabMusic1);
        }
        if(Input.GetKeyDown(KeyCode.X)) {
            soundManager.Playsfx(SoundManager.SFX.sfx2);
        }
        if(Input.GetKeyDown(KeyCode.M)) {
            soundOptions.SetMasterVolume(0);
        }
        if(Input.GetKeyDown(KeyCode.N)) {
            soundOptions.SetMasterVolume(100);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)) {
            soundOptions.SetMusicVolume(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)) {
            soundOptions.SetMusicVolume(100);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)) {
            soundOptions.SetMusicVolume(50);
        }
        if(Input.GetKeyDown(KeyCode.Keypad0)) {
            soundOptions.SetSFXVolume(0);
        }
        if(Input.GetKeyDown(KeyCode.Keypad9)) {
            soundOptions.SetSFXVolume(100);
        }
        if(Input.GetKeyDown(KeyCode.Keypad5)) {
            soundOptions.SetSFXVolume(50);
        }
        if(Input.GetKeyDown(KeyCode.P)) {
            soundManager.PlayBGM();
        }
        if(Input.GetKeyDown(KeyCode.O)) {
            soundManager.PauseBGM();
        }
        if(Input.GetKeyDown(KeyCode.S)) {
            soundManager.StopAllsfx();
        }
    }
}
