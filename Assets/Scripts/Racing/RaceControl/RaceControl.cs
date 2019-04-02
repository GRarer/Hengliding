using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Racing.Agents;
using UnityEngine.SceneManagement;


namespace Racing {

	public class RaceControl : MonoBehaviour {
		public Transform goal;
		public Transform start;
		public int numAI = 1;
		public GameObject gliderPrefab;
		public Text indicator;
		public Text CountDown;
		public Image winScreen;
		private float timer = 3;
		private GameObject[] gliders;
		enum states {COUNTDOWN, INPROGRESS, END};
		private states state = states.COUNTDOWN;

		public int reward = 10000;

		void Start() {
			winScreen.enabled = false;
			gliders = new GameObject[numAI+1];
			Glider glider = GameObject.Instantiate(gliderPrefab, start.position - start.forward*20, start.rotation).GetComponent<Glider>();
			glider.setAgent(new PlayerAgent(glider));
			glider.transform.Find("Main Camera").gameObject.SetActive(true);
			glider.indicator = indicator;
			glider.setRaceStats(SelectedRaceParameters.wingspan, SelectedRaceParameters.dragMultiplier, SelectedRaceParameters.mass, SelectedRaceParameters.controlAuthority);
			glider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
			gliders[0] = glider.gameObject;

			float aiMinSpan = Mathf.Max(SelectedRaceParameters.wingspan, RaceStatsCalculator.MIN_WINGSPAN);
			float aiMaxSpan = Mathf.Min(SelectedRaceParameters.wingspan, RaceStatsCalculator.MAX_WINGSPAN);
			float aiMinDrag = Mathf.Max(SelectedRaceParameters.wingspan, RaceStatsCalculator.MIN_DRAG_MULT);
			float aiMaxDrag = Mathf.Min(SelectedRaceParameters.wingspan, RaceStatsCalculator.MAX_DRAG_MULT);
			float aiMinMass = Mathf.Max(SelectedRaceParameters.wingspan, RaceStatsCalculator.MIN_MASS);
			float aiMaxMass = Mathf.Min(SelectedRaceParameters.wingspan, RaceStatsCalculator.MAX_MASS);
			float aiMinCtrl = Mathf.Max(SelectedRaceParameters.wingspan, RaceStatsCalculator.MIN_AUTHORITY);
			float aiMaxCtrl = Mathf.Min(SelectedRaceParameters.wingspan, RaceStatsCalculator.MAX_AUTHORITY);
			for (int i = 0; i < numAI; i++) {
				glider = GameObject.Instantiate(gliderPrefab, start.position + start.right*(i+1)*3, start.rotation).GetComponent<Glider>();
				glider.setAgent(new AIAgent(glider, goal.position));
				glider.setRaceStats(Random.Range(aiMinSpan, aiMaxSpan), Random.Range(aiMinDrag, aiMaxDrag), Random.Range(aiMinMass, aiMaxMass), Random.Range(aiMinCtrl, aiMaxCtrl));
				glider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
				gliders[i+1] = glider.gameObject;
			}
		}

		void FixedUpdate() {
			if (state == states.COUNTDOWN) {
				if (timer > 0) {
					CountDown.text = Mathf.Ceil(timer).ToString();
					timer -= Time.fixedDeltaTime;
				} else {
					CountDown.text = "";
					foreach(GameObject glider in gliders) {
						glider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
						glider.GetComponent<Rigidbody>().velocity = glider.transform.forward * 10;
					}
					state = states.INPROGRESS;
				}
			} else if (state == states.END) {
				if (timer <= 0) {
					SceneManager.LoadScene("Raise");
				}
				timer -= Time.fixedDeltaTime;
			}
		}

		public void endRace() {
			winScreen.enabled = true;
			state = states.END;
			timer = 5;
			foreach(GameObject glider in gliders) {
				glider.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
			}
			InventoryPersist.setMoney(InventoryPersist.getMoney() + reward);
		}
	}
}