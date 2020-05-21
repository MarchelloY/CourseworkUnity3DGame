using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	private Transform playerBody;
	private float xRotation = 0f;

	public float mouseSensitivity = 100f;
	public float maxAngle = 60f;

	void Start () {
		playerBody = GameObject.Find ("Person").GetComponent<Transform> ();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void FixedUpdate () {
		float mouseX = Input.GetAxis ("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
		float mouseY = Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;
		xRotation -= mouseY;
		xRotation = Mathf.Clamp (xRotation, -maxAngle, maxAngle);
		transform.localRotation = Quaternion.Euler (xRotation, 0f, 0f);
		playerBody.Rotate (Vector3.up * mouseX);
	}

}
