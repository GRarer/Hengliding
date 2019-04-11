using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Racing.Agents;

namespace Racing {
	public class RaceEnd : MonoBehaviour {
		public RaceControl raceControl;
		// Start is called before the first frame update
		void Start() {

		}

		// Update is called once per frame
		void Update() {

		}

		void OnTriggerEnter(Collider other) {
			Debug.Log("colliding");
			Glider g = other.gameObject.GetComponent<Glider>();
			if (g != null) {
				if (g.getAgent() is PlayerAgent) {
					Debug.Log("Player reaches end");
					raceControl.endRace(true);
					//SceneManager.LoadScene("Raise");
				} else {
					Debug.Log("Player loses");
					raceControl.endRace(false);
				}
			}
		}
	}
}
