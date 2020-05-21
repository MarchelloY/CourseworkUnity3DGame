using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskBar : MonoBehaviour {

	public Sprite l0, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10;
	private Image image;

	void Start () {
		image = GameObject.Find ("Bar").GetComponent<Image> ();
		image.sprite = l0;
	}

	void Update () {
		if (PersonUse.count == 1) { image.sprite = l1;}
		if (PersonUse.count == 2) { image.sprite = l2;}
		if (PersonUse.count == 3) { image.sprite = l3;}
		if (PersonUse.count == 4) { image.sprite = l4;}
		if (PersonUse.count == 5) { image.sprite = l5;}
		if (PersonUse.count == 6) { image.sprite = l6;}
		if (PersonUse.count == 7) { image.sprite = l7;}
		if (PersonUse.count == 8) { image.sprite = l8;}
		if (PersonUse.count == 9) { image.sprite = l9;}
		if (PersonUse.count == 10) { image.sprite = l10;}
	}

}
