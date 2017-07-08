using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCountController : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};
	public int stars;

	private Text starCount;

	// Use this for initialization
	void Start () {
		starCount = GetComponent<Text> ();
		starCount.text = stars.ToString ();
	}

	public void AddStars (int starValuePoint) {
		stars += starValuePoint;
		UpdateText ();
	}

	public Status AvailableDefender (int value) {
		if (stars >= value) {
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	public Status SpendStars (int value) {
		if (stars >= value) {
			stars -= value;
			UpdateText ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	void UpdateText () {
		starCount.text = stars.ToString ();
	}
}
