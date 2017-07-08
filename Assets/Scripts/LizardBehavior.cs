using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class LizardBehavior : MonoBehaviour {

	private Attacker attacker;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<Defenders> ()) {
			return;
		} else {
			attacker.Attack(obj);
			GetComponent<Animator> ().SetBool ("isAttacking", true);
		} 
	}
}
