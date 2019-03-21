using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Racing.Agents;

namespace Racing {

	public class RacePhysicsControl : MonoBehaviour {
		public Transform goal;
		public Transform start;
		public int numAi = 1;
		public GameObject gliderPrefab;
		public Text indicator;

		void Start() {
			Glider glider = GameObject.Instantiate(gliderPrefab, start.position, start.rotation).GetComponent<Glider>();
			glider.setAgent(new PlayerPhysicsAgent(glider));
			glider.GetComponent<Rigidbody>().velocity = glider.transform.forward * 10;
			glider.transform.Find("Main Camera").gameObject.SetActive(true);
			glider.indicator = indicator;
			glider.setRaceStats(SelectedRaceParameters.wingspan, SelectedRaceParameters.dragMultiplier, SelectedRaceParameters.mass, SelectedRaceParameters.controlAuthority);
			//glider1.setAgent(new AIPhysicsAgent(glider1.ail, glider1.el, glider1.rud, glider1, goal.position));
		}
	}
}