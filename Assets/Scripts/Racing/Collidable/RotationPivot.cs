using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Racing.Collidables {
	public class RotationPivot : MonoBehaviour {

		public float rotationSpeedX = -60f;
		public float rotationSpeedY = -60f;
		public float rotationSpeedZ = -60f;


		// Start is called before the first frame update
		void Start() {
			rotationSpeedX = Random.Range(-40f, -80f);
			this.transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
			this.transform.Rotate(Vector3.forward, Random.Range(-180f, 180f));
			this.transform.Rotate(Vector3.up, Random.Range(-180f, 180f));
		}

		// Update is called once per frame
		void Update() {
			this.transform.Rotate(Vector3.up, rotationSpeedX * Time.deltaTime);
		}
	}

}
