using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PersonController : MonoBehaviour {

	private CharacterController controller;
	private Vector3 velocity;
	private Animator animatorHead;
	private Transform transformHead;
	private Camera mainCamera;
	private bool hitHead;
	private bool fb;
	private float distance;

	public float speed;
	public float jumpSpeed;
	public float gravity;
	public static float fps;

	void Start () {
		controller = gameObject.GetComponent<CharacterController> ();
		animatorHead = GameObject.Find ("Head").GetComponent<Animator> ();
		transformHead = GameObject.Find ("Head").GetComponent<Transform>();
		mainCamera = GameObject.FindWithTag ("MainCamera").GetComponent<Camera> ();
		fb = false;
	}

	void FixedUpdate () {
		animatorHead.SetBool ("isRunning", true);
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		transformHead.localPosition = new Vector3(0f, controller.height / 3f, 0f);
		if (Input.GetKey (KeyCode.LeftControl)) distance = 1f; else distance = 1.6f;
		hitHead = Physics.Raycast (transform.position, Vector3.up, distance);
		if (controller.isGrounded) {
			if (velocity.y <= 0) velocity.y = -1f;
			if (Input.GetButton ("Jump")) velocity.y = Mathf.Sqrt (2f * jumpSpeed * gravity);
		}
		if (hitHead) velocity.y = 0f;
		velocity.y -= gravity * Time.fixedDeltaTime;
		if (Input.GetKey (KeyCode.LeftControl)) {
			controller.height = 1f;
			fb = true;
		} else if (!hitHead) {
			if (fb) controller.height = 1f;
			else controller.height = 2f;
			fb = false;
		}
		animatorHead.speed = 1;
		float view = mainCamera.fieldOfView;
		if (view > 60) mainCamera.fieldOfView -= 2;
		if (z != 0 || x != 0) {
			if (Input.GetKey (KeyCode.LeftShift) && 
				!Input.GetKey (KeyCode.LeftControl)) {
				if (view < 70) view += 1;
				animatorHead.speed = 2;
				mainCamera.fieldOfView = view;
				speed = 12f;
			} else speed = 8f;
		}
		if (x != 0 && z != 0) speed /= Mathf.Sqrt (2);
		if (x == 0 && z == 0) animatorHead.SetBool ("isRunning", false);
		controller.Move (((transform.right * x + transform.forward * z) * speed + velocity) * Time.fixedDeltaTime);
	}

}