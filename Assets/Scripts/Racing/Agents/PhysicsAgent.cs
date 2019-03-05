using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents {
	public abstract class PhysicsAgent {

		protected Glider glider;

		protected bool inputEnabled = true;
		public abstract Vector3 getInput();

		public void disableInput() {
			inputEnabled = true;
		}

		public void enableInput() {
			inputEnabled = true;
		}


	}
}
