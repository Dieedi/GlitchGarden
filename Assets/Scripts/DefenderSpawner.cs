using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera GameCamera;

	private GameObject Parent;
	private StarCountController starController;
	private Defenders defender;

	void Start () {
		Parent = GameObject.Find ("Defenders");

		if (!Parent) {
			Parent = new GameObject("Defenders");
		}

		starController = GameObject.FindObjectOfType<StarCountController> ();
	}

	void OnMouseDown () {
		if (Buttons.Defender != null && starController.SpendStars (Buttons.Defender.GetComponent<Defenders> ().cost) == StarCountController.Status.SUCCESS) {
			GameObject newDefender = Instantiate (Buttons.Defender, SnapToGrid (CalculateWorldPointOfMouseClick (Input.mousePosition)), Quaternion.identity) as GameObject;
			newDefender.transform.parent = Parent.transform;

			Buttons.Defender = null;
		}
	}

	Vector2 CalculateWorldPointOfMouseClick (Vector2 mousePosition) {
		return GameCamera.ScreenToWorldPoint (mousePosition);
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newPosX = Mathf.RoundToInt (rawWorldPos.x);
		float newPosY = Mathf.RoundToInt (rawWorldPos.y);

		return new Vector2 (newPosX, newPosY);
	}
}
