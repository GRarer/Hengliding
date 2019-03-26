using UnityEngine;

namespace Racing.Collidables {
	public abstract class RaceCollidable : MonoBehaviour {



		//Applies all effects of the hinderance or boost
		public void applyAllEffects(Glider glider) {
			Debug.Log("Collision");
			applyGeneralEffect(glider);
			applySpecificEffect(glider);
		}
		
		//Applies effects common to all hinderances or boosts
		public abstract void applyGeneralEffect(Glider glider);
		//Applies effects of that specific hinderance or boost
		public abstract void applySpecificEffect(Glider glider);
	}
}