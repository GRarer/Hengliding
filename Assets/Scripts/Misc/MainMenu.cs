using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainCanvas, settingsCanvas, creditsCanvas;
	public SoundOptions soundOptions;
	public SoundManager soundManager;

	void Start() {
		soundOptions = SoundManagerStaticReference.GetSoundOptions();
	}

	public void play() {
		SceneManager.LoadScene("Raise");
	}
	public void newGame() {
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("Raise");
	}

	public void showSettings() {
		settingsCanvas.SetActive(true);
	}

	public void hideSettings() {
		settingsCanvas.SetActive(false);
	}

	public void showCredits() {
		creditsCanvas.SetActive(true);
	}

	public void hideCredits() {
		creditsCanvas.SetActive(false);
	}

	public void quit() {
		Application.Quit();
	}

	public void setMasterVolume(int volume) {
		soundOptions.SetMasterVolume(volume);
	}

	public void setSFXVolume(int volume) {
		soundOptions.SetMusicVolume(volume);
	}

	public void setMusicVolume(int volume) {
		soundOptions.SetSFXVolume(volume);
	}
}
