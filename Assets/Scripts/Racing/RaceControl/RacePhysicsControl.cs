using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Racing.Agents;

namespace Racing {

	public class RacePhysicsControl : MonoBehaviour {
		public Transform goal;
		public Glider glider;
		public Glider glider2;
		void Start() {
			glider.setAgent(new AIPhysicsAgent(glider.ail, glider.el, glider.rud, glider, goal.position));
			glider2.setAgent(new PlayerPhysicsAgent(glider2.ail, glider2.el, glider2.rud, glider2));
		}
	}
}