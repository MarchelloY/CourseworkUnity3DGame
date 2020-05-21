using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonUse : MonoBehaviour {

	private bool enter;
	private RaycastHit hit;
	private static float fps;
	private bool flag;

	public static int count;

	void Start () {
		flag = false;
		count = 0;
	}

	void Update () {
		enter = false;
		if (Physics.Raycast(transform.position, transform.forward, out hit, 3f)) {
			if (hit.transform.tag == "Door") {
				enter = true;
				if (Input.GetKeyDown (KeyCode.E)) {
					Animator anim = hit.transform.parent.parent.GetComponent<Animator> ();
					anim.SetBool ("Open", !anim.GetBool("Open"));
				}
			}
			if (hit.transform.tag == "Mask") {
				enter = true;
				if (Input.GetKeyDown (KeyCode.E)) {
					Destroy (hit.transform.parent.gameObject);
					count++;
				}
			}
		}
		if (count == 10) 
		if (Input.GetKeyDown (KeyCode.Escape)) {
			flag = !flag;
			if (flag) {
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
			} else {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}

	}

	void OnGUI() {
		fps = 1.0f / Time.deltaTime;
		GUI.Label (new Rect (5, 0, 150, 60), "FPS: " + (int)fps);
		if (count == 10) {
			GUI.Label (new Rect (5, 20, 150, 60), "Найдены все маски! Поздравляю!");
			if (GUI.Button (new Rect (5, 60, 60, 25), "Выход!")) Application.Quit();
		} else GUI.Label (new Rect (5, 20, 150, 60), "Найдено масок: " + count + "/10");
		if (enter == true) GUI.Label (new Rect (5, 40, 150, 60), "Нажмите 'E'");

	}

}