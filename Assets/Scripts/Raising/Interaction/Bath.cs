using UnityEngine;

namespace Raising.Interaction {

	public class Bath : MonoBehaviour {

		public bool filled = false;
        public bool occupied = false;
		public GameObject water;
		public Material[] levelMaterials;

		public void fill() {
			filled = true;
			water.SetActive(true);
		}

        public void setOccupied()
        {
            occupied = true;
        }
		public void unFill() {
			filled = false;
            occupied = false;
			water.SetActive(false);
		}

		public void RaiseLevel() {
			InventoryPersist.setBathLevel(InventoryPersist.getBathLevel() + 1);
			
			if (InventoryPersist.getBathLevel() >= levelMaterials.Length) {
				Debug.LogError("Bath level exceeds number of upgrade materials!");
			} else {
				GetComponent<MeshRenderer>().sharedMaterial = levelMaterials[InventoryPersist.getBathLevel()];
			}
		}
	}
}