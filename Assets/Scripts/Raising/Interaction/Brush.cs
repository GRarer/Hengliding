using UnityEngine;

namespace Raising.Interaction {

	public class Brush : Draggable {

		private float brushProgress = 0;
        public float maxBrushTimer = 2;

        // Used in findHenUnder(); helps the raycast cover a larger area, making sure there is still a chicken beneath the brush.
        public float henSearchRadius = 0.025f;

        private float checkHenStillBeingPetTimer = 0.5f;
        private Hen lastHen;
		public Material[] levelMaterials;

        protected override float getFloatHeight() {
			return 0.5f;    //change if necessary
		}

		void Update() {
			Hen under = findHenUnder();
            bool henFound = false;
			if (under != null) {
                henFound = true;
                if (brushProgress == 0 || lastHen.GetInstanceID() != under.GetInstanceID()) {
                    StopHenFlap(lastHen);
                    lastHen = under;
                    brushProgress = maxBrushTimer;
                    MakeHenFlap(lastHen);
                }
			}
            if (!henFound && checkHenStillBeingPetTimer < 0) {
                StopHenFlap(lastHen);
                brushProgress = 0;
            }
            if (checkHenStillBeingPetTimer < 0) {
                checkHenStillBeingPetTimer = 0.5f;
            }
            checkHenStillBeingPetTimer -= Time.deltaTime;
            if (brushProgress > 0) {
                brushProgress -= Time.deltaTime;
                if (brushProgress <= 0) {
                    StartCoroutine(lastHen.love.increase(1));
                    brushProgress = 0;
                }
            } else {
                brushProgress = 0;
            }
		}

        void MakeHenFlap(Hen h) {
            if (h != null) {
                h.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
			    h.GetComponent<Animator>().SetTrigger("inWater");
            }
        }

        void StopHenFlap(Hen h) {
            if (h != null)
                h.GetComponent<Animator>().ResetTrigger("inWater");
            // TODO actually stop animation
        }

        protected Hen findHenUnder() {
			RaycastHit under;
			if (Physics.Raycast(gameObject.transform.position, Vector3.down, out under)) {
				if (under.collider.gameObject.GetComponent<Hen>() != null) {
                    return (under.collider.gameObject.GetComponent<Hen>());
                }
			}
            for (int i = -2; i <= 2; i++) {
                for (int j = -2; j <= 2; j++) {
                    if (i!=0 && j!=0) {
                        if (Physics.Raycast(gameObject.transform.position + new Vector3(henSearchRadius*i, 0, henSearchRadius*j), Vector3.down, out under)) {
                            if (under.collider.gameObject.GetComponent<Hen>() != null) {
                                return (under.collider.gameObject.GetComponent<Hen>());
                            }
                        }
                    }
                }
            }
			return null;
		}

		public void RaiseLevel() {
			InventoryPersist.setPettingLevel(InventoryPersist.getPettingLevel() + 1);
			
			if (InventoryPersist.getPettingLevel() >= levelMaterials.Length) {
				Debug.LogError("Brush level exceeds number of upgrade materials!");
			} else {
				GetComponent<MeshRenderer>().sharedMaterial = levelMaterials[InventoryPersist.getPettingLevel()];
			}
		}
	}
}