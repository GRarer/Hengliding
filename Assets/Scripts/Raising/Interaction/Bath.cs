using UnityEngine;

namespace Raising.Interaction {

	public class Bath : Upgradeable {

		public bool filled = false;
        public bool occupied = false;
		public GameObject water;

		void Start() {
			SetMaterial(InventoryPersist.getBathLevel());
		}

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
			SetMaterial(InventoryPersist.getBathLevel());
		}
	}
}