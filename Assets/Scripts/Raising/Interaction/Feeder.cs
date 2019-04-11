using UnityEngine;

namespace Raising.Interaction {

	public class Feeder : MonoBehaviour {

		
		public Material[] levelMaterials;
		public Animator feederAnimator;
		public GameObject foodPrefab;

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
			InventoryPersist.setFeederLevel(InventoryPersist.getFeederLevel() + 1);
			
			if (InventoryPersist.getFeederLevel() >= levelMaterials.Length) {
				Debug.LogError("Feeder level exceeds number of upgrade materials!");
			} else {
				GetComponent<MeshRenderer>().sharedMaterial = levelMaterials[InventoryPersist.getFeederLevel()];
			}
		}
	}
}