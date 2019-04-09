using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
	// Update is called once per frame

	public GameObject pauseMenu;

	void Update() {
		if(Input.GetButtonDown("Cancel")) {
			if(pauseMenu.activeInHierarchy) {
				hidePauseMenu();
			} else {
				showPauseMenu();
			}
		}
	}

	public void showPauseMenu() {
		pauseMenu.SetActive(true);
	}

	public void hidePauseMenu() {
		pauseMenu.SetActive(false);
	}

	public void mainMenu() {
		SceneManager.LoadScene("Title");
	}
}
