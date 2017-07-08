using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class FoxBehavior : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		GameObject obj = collider.gameObject;

		if (!obj.GetComponent<Defenders> ()) {
			return;
		}
			
		if (obj.GetComponent<Stone> ()) {
			anim.SetTrigger ("jumpTrigger");
		} else {
			attacker.Attack(obj);
			anim.SetBool ("isAttacking", true);
		}
	}
}
