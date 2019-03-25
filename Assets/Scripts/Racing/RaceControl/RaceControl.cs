using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Racing.Agents;

namespace Racing {

	public class RaceControl : MonoBehaviour {
		public Transform goal;
		public Transform start;
		public int numAI = 1;
		public GameObject gliderPrefab;
		public Text indicator;

		void Start() {
			Glider glider = GameObject.Instantiate(gliderPrefab, start.position - start.forward*20, start.rotation).GetComponent<Glider>();
			glider.setAgent(new PlayerAgent(glider));
			glider.GetComponent<Rigidbody>().velocity = glider.transform.forward * 10;
			glider.transform.Find("Main Camera").gameObject.SetActive(true);
			glider.indicator = indicator;
			glider.setRaceStats(SelectedRaceParameters.wingspan, SelectedRaceParameters.dragMultiplier, SelectedRaceParameters.mass, SelectedRaceParameters.controlAuthority);

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
				glider.GetComponent<Rigidbody>().velocity = glider.transform.forward * 10;
				glider.setRaceStats(Random.Range(aiMinSpan, aiMaxSpan), Random.Range(aiMinDrag, aiMaxDrag), Random.Range(aiMinMass, aiMaxMass), Random.Range(aiMinCtrl, aiMaxCtrl));
			}
		}
	}
}