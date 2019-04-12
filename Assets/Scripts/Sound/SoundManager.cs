using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public enum SFX {
		weabMusic1,
		sfx2,
		weabMusic2,
		chickenMarch,
		chickenMarchDubstep,
		Loss,
		Victory,
		Race,
		Farm,
		Main,
	}

	public enum SFXv2 {

		cluck1,
		cluck2,
		cluck3,
		cluck4,
		cluck5,
		Loss,
		Victory,
	}

	[SerializeField] AudioSource bgm;
	[SerializeField] AudioSource[] sfxArray;
	[SerializeField] AudioSource[] generalUseAudioSources;
	[SerializeField] EnumClipPair[] audioClips;

	static SoundManager instance;

	public static SoundManager Instance() {return instance;}

	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Destroy(this.gameObject);
		}
	}

	void Start() {
		// PlayBGM();
	}

	public void PlayBGM() {
		bgm.Stop();
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

	public void SetBGM(SFX music) {
		bgm.clip = sfxArray[(int) music].clip;
	}

	public void Playsfx(SFX sfxEnum) {
		if (sfxArray[(int)sfxEnum].isPlaying) {
			sfxArray[(int)sfxEnum].Stop();
		}
		sfxArray[(int)sfxEnum].Play();
	}

	public void PlayAnySFX(SFXv2 sfx) {
		foreach (AudioSource source in generalUseAudioSources) {
			if (!source.isPlaying) {

				foreach (var pair  in audioClips) {
					if (pair.clipName == sfx) {

						source.clip = pair.clip;
						source.Play();
					}
				}
				break;
			}
		}
	}

	public void StopAllsfx() {
		for (int i = 0; i < sfxArray.Length; i++) {
			sfxArray[i].Stop();
		}
	}
	[System.Serializable]
	public class EnumClipPair {
		public SoundManager.SFXv2 clipName;
		public AudioClip clip;
	}

}