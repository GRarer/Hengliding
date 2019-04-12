using UnityEngine;

namespace Raising.Interaction
{

    public class Treadmill : MonoBehaviour
    {
        public bool active = false;
        public bool occupied = false;
		public Material[] levelMaterials;
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
			
			if (InventoryPersist.getTreadmillLevel() >= levelMaterials.Length) {
				Debug.LogError("Treadmill level exceeds number of upgrade materials!");
			} else {
				GetComponent<MeshRenderer>().sharedMaterial = levelMaterials[InventoryPersist.getTreadmillLevel()];
			}
		}
    }
}