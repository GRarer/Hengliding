using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Racing.Agents;
using Racing.Collidables;

public class Glider : MonoBehaviour {

	
	

	private Rigidbody rb;
	public float thrust = 0;
	public float el = 0.002f;
	public float ail = 0.002f;
	public float rud = 0.000125f;
	public float span = .7f;
	public float cord = 0.3f;
	private float AR;
	public float cl0 = 0.1f;
	public float cd0 = 0.01f;
	public float rho = 1.225f;
	public bool rollYawCoupled = false;
	public Text indicator;
	private float alphaCrit = Mathf.PI / 12;
	private PhysicsAgent agent;
	public GameObject collisionExplosion;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.inertiaTensor = new Vector3(.1f,.1f,.1f);
		rb.maxAngularVelocity = 5;
		AR = Mathf.Pow(span, 2) / cord;
		// agent = new PlayerPhysicsAgent(ail, el, rud, this);
		rb.velocity = transform.forward*10;
	}
	
	// Update is called once per frame
	// void Update () {
	// 	if (Input.GetKey(KeyCode.Q)) {
	// 		thrust += Time.deltaTime * 10;
	// 		if (thrust > 200) {
	// 			thrust = 200;
	// 		}
	// 	}
	// 	if (Input.GetKey(KeyCode.E)) {
	// 		thrust -= Time.deltaTime * 10;
	// 		if (thrust < 0) {
	// 			thrust = 0;
	// 		}
	// 	}
	// }

	void FixedUpdate() {
		Vector3 u = agent.getInput();
		rb.AddTorque((-transform.forward * u.z + transform.up * u.y  + transform.right * u.x) * Mathf.Pow(Vector3.Dot(rb.velocity, transform.forward), 2));

		Matrix4x4 R_eb = Matrix4x4.Rotate(rb.rotation);
		Vector3 vel_b = R_eb.inverse.MultiplyVector(rb.velocity);
		float alpha = Mathf.Atan2(-vel_b.y, vel_b.z);

		float alphaErr = 0 - alpha;
		// Debug.Log(alphaErr);

		Vector3 lift = aeroForce();
		// Debug.Log(lift);
		rb.AddForce(transform.forward * thrust + lift);
		rb.AddForce(Vector3.down * 3.3f, ForceMode.Acceleration);

		rb.AddTorque(transform.right * alpha / 15);
		rb.AddTorque(transform.forward * vel_b.x / 20);
	}

	Vector3 aeroForce() {
		Vector3 vel_e = rb.velocity;
		Matrix4x4 R_eb = Matrix4x4.Rotate(rb.rotation);
		Vector3 vel_b = R_eb.inverse.MultiplyVector(vel_e);

		float alpha = Mathf.Atan2(-vel_b.y, vel_b.z);
		// Debug.Log("Vel_b: " + vel_b.ToString());
		indicator.text = string.Format("Airspeed: {0}\nAlpha: {1}\nAlpha Crit: {2}", vel_b.magnitude, alpha, alphaCrit);

		float cl = 0;
		float alphaMax = Mathf.PI / 6;
		
		if (Mathf.Abs(alpha) <= alphaCrit) {
			cl = Mathf.PI*2*alpha + cl0;
		} else if (Mathf.Abs(alpha) <= alphaMax) {
			if (alpha > 0) {
				float clmax = Mathf.PI*2*alphaCrit + cl0;
				cl = clmax * (1 - Mathf.Pow((alpha - alphaCrit) / (alphaMax - alphaCrit), 2));
				
			} else {
				float clmin = -Mathf.PI*2*alphaCrit + cl0;
				cl = clmin * (1 - Mathf.Pow((alpha + alphaCrit) / (alphaMax - alphaCrit), 2));
			}
		}
		
		float cd = cd0 + Mathf.Pow(Mathf.PI*2*alpha + cl0,2) / (Mathf.PI * AR);
		if (Mathf.Abs(alpha) > alphaMax) {
			cd = cd0 + Mathf.Pow(Mathf.PI*2*alphaMax + cl0,2) / (Mathf.PI * AR);
		}

		float D = cd * 0.5f * rho * vel_b.sqrMagnitude * cord * span / 5;
		float L = cl * 0.5f * rho * vel_b.sqrMagnitude * cord * span;


		Matrix4x4 R_w = Matrix4x4.Rotate(Quaternion.Euler(alpha / Mathf.PI * 180, 0, 0));
		Vector3 force = R_w.MultiplyVector(L * Vector3.up - D * Vector3.forward);
		force += Vector3.right * -Mathf.Sign(vel_b.x) * Mathf.Pow(vel_b.x,2) * rho * 0.5f / 5;
		force = R_eb.MultiplyVector(force);

		return force;
	}

	public void setAgent(PhysicsAgent agent) {
		this.agent = agent;
	}
	
	 
	void OnCollisionEnter(Collision other) {
			if (other.relativeVelocity.magnitude > 3) {
				GameObject explosion = GameObject.Instantiate(collisionExplosion);
				explosion.transform.position = transform.position;
				explosion.transform.parent = transform; // setting the parent here instead of during instantiation to avoid any potential scaling issues
				explosion.transform.rotation = transform.rotation;
			}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<RaceCollidable>() != null) {
				Debug.Log("Collidable found");
				RaceCollidable collidable = other.gameObject.GetComponent<RaceCollidable>();
				collidable.applyAllEffects(this);
		}
	}

	
	
}
