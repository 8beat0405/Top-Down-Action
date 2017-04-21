using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFrame : MonoBehaviour {

	[SerializeField]
	private Text frameText;

	private int frame = 0;

	void Update () {
		frame++;
		frameText.text = "Frame : " + frame;
	}
}
