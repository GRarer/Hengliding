using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLine : MonoBehaviour {

	public AnimationCurve motion;
	float startTime;

	// Start is called before the first frame update
	void Start() {
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update() {
		float currTime = Time.time - startTime;
		gameObject.transform.position = gameObject.transform.position + new Vector3(motion.Evaluate(currTime), 0, 0);
	}
}
