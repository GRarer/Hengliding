using System.Collections;
using UnityEngine;

namespace Racing.Collidables {
	public class Thermal : Continuous, Boost {

		public GameObject windLine;

		void Update() {
			if(Random.Range(0.0f, 1.0f) < 0.004) {
				Vector3 spawnPosition = this.transform.position -
					new Vector3(
						Random.Range(-this.transform.localScale.x/2, this.transform.localScale.x/2),
						(this.transform.localScale.y / 2),
						Random.Range(-this.transform.localScale.z/2, this.transform.localScale.z/2)
					);
				Instantiate(windLine, spawnPosition, windLine.transform.rotation);
			}
		}

		public override void applySpecificEffect(Glider glider) {
			boost(glider);
		}

		public void boost(Glider glider) {
			Rigidbody rb = glider.GetComponent<Rigidbody>();
			rb.velocity = rb.velocity + new Vector3(0, 1000 * Time.deltaTime, 0);
		}
	}
}