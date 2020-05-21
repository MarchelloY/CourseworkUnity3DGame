using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
	
	public Sprite arrup, arrdown;
	private SpriteRenderer sr;

	private void Start() {
		sr = GameObject.Find ("Arrow").GetComponent<SpriteRenderer> ();
		sr.sprite = arrup;
	}

	private void OnMouseDown() {
		sr.sprite = arrdown;
	}

	private void OnMouseUp() {
		sr.sprite = arrup;
		SceneManager.LoadScene (1);
	}
}
