using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents {
	public abstract class PhysicsAgent {

		protected Glider glider;
		protected float dMda;
		protected float dNde;
		protected float dLdr;

		public PhysicsAgent(float dMda, float dNde, float dLdr, Glider glider) {
			this.dMda = dMda;
			this.dNde = dNde;
			this.dLdr = dLdr;
			this.glider = glider;
		}
		public abstract Vector3 getInput();

	}
}
