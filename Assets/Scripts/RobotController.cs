using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	private HealthController currentTargetHealthController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * currentSpeed * Time.deltaTime);
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Attacker attacker = collider.GetComponent<Attacker> ();
		if (attacker) {
			Attack (collider.gameObject);
		}
	}

	void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			currentTargetHealthController = currentTarget.GetComponent<HealthController> ();
			currentTargetHealthController.IsTargetDestroy (damage);
		}
	}

	void Attack (GameObject obj) {
		currentTarget = obj;
		StrikeCurrentTarget (10000);
	}
}
