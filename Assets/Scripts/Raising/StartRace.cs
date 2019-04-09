using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRace : MonoBehaviour {
	public void race() {
		SceneManager.LoadScene("HenSelectScreen");
	}
}
