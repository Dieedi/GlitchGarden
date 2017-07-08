using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public GameObject DefenderPrefab;
	public static GameObject Defender;

	private StarCountController starController;
	private Defenders defender;
	private Text costText;

	void Start () {
		starController = GameObject.FindObjectOfType<StarCountController> ();
		defender = DefenderPrefab.GetComponent<Defenders> ();

		costText = gameObject.GetComponentInChildren<Text> ();
		if (!costText) {
			Debug.LogError ("No Text Component attached");
		}
		costText.text = defender.cost.ToString ();
	}

	void Update () {
		if (starController.AvailableDefender (defender.cost) == StarCountController.Status.SUCCESS) {
			GetComponent<SpriteRenderer> ().color = Color.white;
		} else {
			GetComponent<SpriteRenderer> ().color = Color.black;
		}
	}

	void OnMouseDown () {
		Defender = DefenderPrefab;
	}
}
