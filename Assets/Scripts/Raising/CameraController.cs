using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	/**
	 * The camera controls are as follows:
	 * Arrows/WASD: Rotate Camera
	 * RMB + drag: Rotate Camera
	 * E: Reset to default position
	 * Scroll wheel: adjust zoom
	 */
	//These are just private so they do not clutter the component box, but these can be made public and adjusted if desired.
	private float zoomSpeedExp = 2f;  //The rate at which the camera exponentially zooms to achieve the desired distance.
	private float zoomSpeedLin = 1;     //The rate at which the camera linearally zooms to achieve the desired distance.
	private float zoomControlMultiplier = 7;   //The rate at which scrolling the mouse changes the zoom level of the camera.
	private float rotateSpeedKeys = 15;
	private float minZoomDistance = 2;   //The maximum distance allowed for the camera zoom.
	private float maxZoomDistance = 10;    //The minimum distance allowed for the camera zoom.
	private float rotMomentumDecayExp = 3f; //The rate at which the camera exponentially slows down its rotation.
	private float rotMomentumDecayLin = 1.0f;   //The rate at which the camera linerally slows down its rotation.
	private float linMomentumDecayExp = 1.0f;      //The rate at which the camera exponentially slows down its translation.
	private float linMomentumDecayLin = 0.05f;      //The rate at which the camera linearally slows down its translation.
	private float rotateSpeed = 0.05f;      //The rate at which dragging adjusts the camera's rotational momentum.
	private float panSpeed = 4f;
	public bool invertCameraX = false;  //Whether to invert the x axis when rotating the camera.
	public bool invertCameraY = false;  //Whether to invert the y axis when rotating the camera.
	private Vector3 lastMousePos = Vector3.zero;    //The previous position of the mouse, used to calculate dragging.
	private Vector2 rotationMomentum = Vector2.zero;    //The rotational momentum of the camera, used to fluidly rotate the camera.
	private float maintainedDistance = 1;   //The distance intended to be maintained between the camera and the terrain, adjusted via mouse wheel.

	private Vector3 focus; //The current position that is the focus of the camera.
	public Vector3 idealFocus = Vector3.zero; //The position that the camera's focus will gradually move towards.

	public static bool inputEnabled = true;

	public GameObject focusObject;	//The object to intially have the camera look at.
	public float startingYOffset;	//The amount of y-value to add to the center of the startingObject to make the camera have a focus that is not inside the starting object.

	// Use this for initialization
	void Start() {
		maintainedDistance = (minZoomDistance + maxZoomDistance) / 2f;
		if (focusObject != null) {
			idealFocus = focusObject.transform.position + new Vector3(0,startingYOffset,0);
		}
		resetCamera();
	}

	// Update is called once per frame
	void Update() {
		if (!inputEnabled) {
			return;
		}

		//Reset everything by pressing the E button
		if (Input.GetAxis("E") > 0) {
			resetCamera();
		}

		//BEGINNING OF SETUP SECTION
		float distance = Mathf.Abs((gameObject.transform.position - focus).magnitude);

		//END OF SETUP SECTION, BEGINNING OF INPUT SECTION
		if (Input.GetAxis("KeysOnlyVertical") != 0) {
			Vector3 fward = transform.rotation * Vector3.forward;
			fward.y = 0;
			fward = fward.normalized;
			idealFocus += panSpeed * Time.deltaTime * Input.GetAxis("KeysOnlyVertical") * fward;
		}
		if (Input.GetAxis("KeysOnlyHorizontal") != 0) {
			Vector3 sidew = transform.rotation * Vector3.right;
			sidew.y = 0;
			sidew = sidew.normalized;
			idealFocus += panSpeed * Time.deltaTime * Input.GetAxis("KeysOnlyHorizontal") * sidew;
		}

		if (focusObject != null) {
			Vector3 pos = focusObject.transform.position;
			Vector3 sca = focusObject.transform.lossyScale;
			idealFocus.x = Mathf.Clamp(idealFocus.x, pos.x-Mathf.Abs(sca.x/2), pos.x+Mathf.Abs(sca.x/2));
			idealFocus.z = Mathf.Clamp(idealFocus.z, pos.z-Mathf.Abs(sca.z/2), pos.z+Mathf.Abs(sca.z/2));
		}

		if (Input.GetAxis("AltSelect") > 0) {
			rotationMomentum += new Vector2((Input.mousePosition.x - lastMousePos.x) * rotateSpeed, (Input.mousePosition.y - lastMousePos.y) * rotateSpeed);
		}
		if (Mathf.Abs(rotationMomentum.x) > (rotMomentumDecayLin + rotMomentumDecayExp * rotationMomentum.x) * Time.deltaTime) {
			rotationMomentum.x -= (rotMomentumDecayLin + rotMomentumDecayExp * rotationMomentum.x * Mathf.Sign(rotationMomentum.x)) * Time.deltaTime * Mathf.Sign(rotationMomentum.x);
		} else {
			rotationMomentum.x = 0;
		}
		if (Mathf.Abs(rotationMomentum.y) > (rotMomentumDecayLin + rotMomentumDecayExp * rotationMomentum.y) * Time.deltaTime) {
			rotationMomentum.y -= (rotMomentumDecayLin + rotMomentumDecayExp * rotationMomentum.y * Mathf.Sign(rotationMomentum.y)) * Time.deltaTime * Mathf.Sign(rotationMomentum.y);
		} else {
			rotationMomentum.y = 0;
		}
		lastMousePos = Input.mousePosition;

		//This has the mouse wheel control the current zoom distance.
		if (Input.GetAxis("MouseScrollWheel") != 0) {
			maintainedDistance -= Input.GetAxis("MouseScrollWheel") * zoomControlMultiplier;
			maintainedDistance = Mathf.Clamp(maintainedDistance, minZoomDistance, maxZoomDistance);
		}

		//END OF INPUT SECTION, BEGINNING OF MOVEMENT SECTION

		//First, the focus is moved according to any translation inputs.
		float sep = (focus-idealFocus).magnitude;
		if (sep > sep*linMomentumDecayExp+linMomentumDecayLin){
			focus += (idealFocus-focus).normalized*(sep*linMomentumDecayExp+linMomentumDecayLin);
		} else {
			focus = idealFocus;
		}
		// focus += Quaternion.Euler(0, gameObject.transform.rotation.eulerAngles.y, 0) * new Vector3(linearMomentum.x, 0, linearMomentum.y);
		// var unclampedFocus = focus;
		// focus = new Vector3(Mathf.Clamp(focus.x, -5, maxXPos), focus.y, Mathf.Clamp(focus.z, -5, maxYPos));
		// if (!focus.Equals(unclampedFocus)) {
		// 	linearMomentum = Vector2.zero;
		// }

		//Next, the distance is increased or decreased, depending on the current intended distance (controlled by scrolling).
		//The difference between the real and ideal distances (denoted D) decreases at a rate of E*D+L, where E is the exponential decay factor and L is the linear decay factor.
		distance += zoomSpeedExp * Time.deltaTime * (maintainedDistance - distance);
		if (Mathf.Abs(maintainedDistance - distance) > zoomSpeedLin * Time.deltaTime) {
			distance += zoomSpeedLin * Mathf.Sign(maintainedDistance - distance) * Time.deltaTime;
		} else {
			distance = maintainedDistance;
		}

		//Lastly, the camera is rotated, and the camera's position is reestablished using the new focus, distance, and direction.
		Quaternion newDir = gameObject.transform.rotation;
		newDir.eulerAngles += new Vector3(-rotationMomentum.y * (invertCameraY ? -1 : 1), rotationMomentum.x * (invertCameraX ? -1 : 1), 0);
		float prevX = newDir.eulerAngles.x;
		newDir.eulerAngles = new Vector3(Mathf.Clamp(newDir.eulerAngles.x, 15, 75), newDir.eulerAngles.y, newDir.eulerAngles.z);
		if (Mathf.Abs(prevX - newDir.eulerAngles.x) > 0.001) {	//float inequality
			rotationMomentum.y = 0;
		}
		if (Mathf.Abs(newDir.eulerAngles.z) > 0.001) {
			newDir.eulerAngles = new Vector3(newDir.eulerAngles.x, newDir.eulerAngles.y, 0);
		}
		gameObject.transform.position = focus - ((newDir) * Vector3.forward) * distance;
		gameObject.transform.rotation = newDir;
	}

	public void resetCamera() {
		gameObject.transform.position = new Vector3(-1, 1, -1).normalized * maintainedDistance * -1;
		gameObject.transform.rotation = Quaternion.Euler(45, 45, 0);
	}
}
