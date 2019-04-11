using UnityEngine;

namespace Raising.Interaction {

	public class Bath : MonoBehaviour {

		public bool filled = false;
        public bool occupied = false;
		public GameObject water;

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
	}
}