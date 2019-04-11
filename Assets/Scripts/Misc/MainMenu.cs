using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject mainCanvas, settingsCanvas, creditsCanvas;

	public void play() {
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
}
