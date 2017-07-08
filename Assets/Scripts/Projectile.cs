using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float Speed, Damage;

	private GameObject CurrentTarget;
	private HealthController currentTargetHealthController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Speed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.GetComponent<Attacker> ()) {
			CurrentTarget = collider.gameObject;
			StrikeCurrentTarget (Damage);
		}
	}

	public void StrikeCurrentTarget (float damage) {
		currentTargetHealthController = CurrentTarget.GetComponent<HealthController> ();
		Destroy (gameObject);

		if (currentTargetHealthController && currentTargetHealthController.IsTargetDestroy (damage) == true) {
			GetComponent<Animator> ().SetBool ("isAttacking", false);
		}
	}
}
