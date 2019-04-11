using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing.Agents {
	public abstract class Agent {

		protected Glider glider;
		protected float Lda;
		protected float Mde;
		protected float Ndr;

		public Agent(Glider glider) {
			this.Lda = glider.getLda();
			this.Mde = glider.getMde();
			this.Ndr = glider.getNdr();
			this.glider = glider;
		}
		public abstract Vector3 getInput();

	}
}
