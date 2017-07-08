using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject Projectile, Gun;

	private GameObject ProjectileParent;
	private GameObject mySpawner;
	private Animator animator;

	void Start () {
		animator = GetComponent<Animator> ();
		ProjectileParent = GameObject.Find ("Projectiles");

		if (!ProjectileParent) {
			ProjectileParent = new GameObject("Projectiles");
		}

		SetMyLineSpawner ();
	}

	void Update () {
		if (IsAttackerAhead () && animator) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	void SetMyLineSpawner () {
		GameObject[] spawners = GameObject.FindGameObjectsWithTag ("Spawner");

		foreach (GameObject spawner in spawners) {
			if (spawner.transform.position.y == transform.position.y) {
				mySpawner = spawner;
				return;
			}
		}

		Debug.LogError ("Can't find my spawner ! ");
	}

	bool IsAttackerAhead () {
		if (mySpawner.transform.childCount <= 0) {
			return false;
		}

		foreach (Transform attacker in mySpawner.transform) {
			if (attacker.transform.position.x > transform.position.x && attacker.transform.position.x <= 11) {
				return true;
			}
		}

		return false;
	}

	private void Fire () {
		GameObject newProjectile = Instantiate (Projectile);
		newProjectile.transform.parent = ProjectileParent.transform;
		newProjectile.transform.position = Gun.transform.position;
	}
}
