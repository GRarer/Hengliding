using UnityEngine;

namespace Raising.Interaction
{

    public class Treadmill : Upgradeable
    {
        public bool active = false;
        public bool occupied = false;
		void Start() {
			SetMaterial(InventoryPersist.getTreadmillLevel());
		}
        void OnMouseDown()
        {
            active = true;
            Debug.Log("clicked");
        }

        public void setOccupied()
        {
            occupied = true;
        }

        public void setInactive()
        {
            active = false;
            occupied = false;
        }

		public void RaiseLevel() {
			InventoryPersist.setTreadmillLevel(InventoryPersist.getTreadmillLevel() + 1);
			SetMaterial(InventoryPersist.getTreadmillLevel());
		}
    }
}