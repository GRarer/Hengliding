using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public enum SFX {
        sfx1,
        sfx2,
    }

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource[] sfxArray;

    void Start() {
        PlayBGM();
    }

    public void PlayBGM() {
        bgm.Play();
    }

    public void PauseBGM() {
        bgm.Pause();
    }

    public void StopBGM() {
        bgm.Stop();
    }

    public void UnPauseBGM() {
        bgm.UnPause();
    }

    public void Playsfx(SFX sfxEnum) {
        if (sfxArray[(int) sfxEnum].isPlaying) {
            sfxArray[(int) sfxEnum].Stop();
        }
        sfxArray[(int) sfxEnum].Play();
    }

    public void StopAllsfx() {
        for (int i = 0; i < sfxArray.Length; i++) {
            sfxArray[i].Stop();
        }
    }

}
