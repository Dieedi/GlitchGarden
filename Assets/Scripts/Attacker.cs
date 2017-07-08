using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEveryXSeconds;
	public float damagePerSecond;
	public bool isAttacking = false;

	private float currentSpeed;
	private GameObject currentTarget;
	private HealthController currentTargetHealthController;
	private float timer = 0;

	// Use this for initialization
	void Start () {
		Rigidbody2D thisRigibody = gameObject.GetComponent<Rigidbody2D> ();
		thisRigibody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isAttacking) {
			transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		} else {
			timer += Time.deltaTime;
			if (timer >= 1) {
				StrikeCurrentTarget (damagePerSecond);
				timer = 0;
			}
		}

		if (!currentTarget) {
			GetComponent<Animator> ().SetBool ("isAttacking", false);
		}
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			currentTargetHealthController = currentTarget.GetComponent<HealthController> ();
		
			if (currentTargetHealthController && currentTargetHealthController.IsTargetDestroy (damage) == true) {
				isAttacking = false;
			}
		}
	}

	public void Attack (GameObject obj) {
		isAttacking = true;
		currentTarget = obj;
	}
}
