using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {


	public float health = 100f;

	public bool IsTargetDestroy (float damage) {
		if ((health -= damage) <= 0) {
			Die ();
			return true;
		}

		return false;
	}

	public void Die () {
		Attacker isAttacker = gameObject.GetComponent<Attacker> ();
		if (isAttacker) {
			isAttacker.isAttacking = false;
			Spawner.attackersOnBoard--;
			print (Spawner.attackersOnBoard);
		}
		Destroy (gameObject);
	}
}
