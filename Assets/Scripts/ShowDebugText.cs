using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDebugText : MonoBehaviour {

	[SerializeField]
	private Text eventText;

	[SerializeField]
	private Text durationText;

	private float duration;
	private bool detectDuration;

	void Update() {
		if (detectDuration) {
			duration++;
			this.durationText.text = "Duration : " + duration;
		}
	}

	public void OnPointerDown() {
		detectDuration = true;
		this.eventText.text = "Gesture : OnPointerDown";
		Debug.Log ("OnPointerDown");
	}

	public void OnPointerUp() {
		this.ResetDuration ();
		this.eventText.text = "Gesture : OnPointerUp";
		Debug.Log ("OnPointerUp");
	}

	public void OnBeginDrag() {
		this.ResetDuration ();
		this.eventText.text = "Gesture : OnBeginDrag";
		Debug.Log ("OnBeginDrug");
	}

	public void OnDrag() {
		this.eventText.text = "Gesture : OnDrag";
		Debug.Log ("OnDrug");
	}

	public void OnEndDrag() {
		this.eventText.text = "Gesture : OnEndDrag";
		Debug.Log ("OnEndDrug");
	}

	private void ResetDuration() {
		detectDuration = false;
		duration = 0;
		this.durationText.text = "Duration : " + duration;
	}
}
