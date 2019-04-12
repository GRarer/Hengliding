using UnityEngine;

namespace Raising.Interaction {

	public class Feeder : Upgradeable {

		
		public Animator feederAnimator;
		public GameObject foodPrefab;

		void Start() {
			SetMaterial(InventoryPersist.getFeederLevel());
		}
		void OnMouseEnter() {
			feederAnimator.SetBool("isOpen", true);
		}

		void OnMouseExit() {
			feederAnimator.SetBool("isOpen", false);
		}

		void OnMouseDown() {
			Instantiate(foodPrefab, gameObject.transform.position + new Vector3(0, 1, 0), foodPrefab.transform.rotation);
		}

		void OnMouseDrag() {
			//move food to mouse 
		}

		void OnMouseUp() {
			//drop the food
		}

		public void RaiseLevel() {
			InventoryPersist.setBathLevel(InventoryPersist.getBathLevel() + 1);
			SetMaterial(InventoryPersist.getBathLevel());
		}
	}
}