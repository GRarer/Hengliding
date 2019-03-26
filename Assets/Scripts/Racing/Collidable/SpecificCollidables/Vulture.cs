using UnityEngine;


namespace Racing.Collidables {
	public class Vulture : Instantaneous, Hinderance {

		private const float BOOST_STRENGTH = 0.5f;

		public override void applySpecificEffect(Glider glider) {
			Rigidbody rb = glider.GetComponent<Rigidbody>();

			rb.velocity *= Vulture.BOOST_STRENGTH;

		}
	}
}