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
			if (other.gameObject.GetComponent<Glider>() != null) {
				if (other.gameObject.GetComponent<Glider>().getAgent() is PlayerAgent) {
					Debug.Log("Player reaches end");
					//SceneManager.LoadScene("Raise");
				}
			}
		}
	}
}
