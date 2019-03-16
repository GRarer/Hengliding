using System.Collections;
using UnityEngine;

namespace Racing.Collidables {
	public class Thermal : Boost {
		public override void applySpecificEffect(Racer racer) {
			//
		}

		public void boost(Glider glider) {
			Rigidbody rb = glider.GetComponent<Rigidbody>();
			rb.velocity = rb.velocity + new Vector3(0, 1, 0);
		}
	}
}