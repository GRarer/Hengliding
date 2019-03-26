using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLine : MonoBehaviour {


	// Start is called before the first frame update
	void Start() {
		
	}

	// Update is called once per frame
	void Update() {
		transform.position = transform.position + new Vector3(0, 10, 0) * Time.deltaTime;
		if(Random.Range(0.0f, 1.0f) < 0.002) {
			GetComponentInChildren<Animator>().SetTrigger("Twirl");
		}
	}
}
