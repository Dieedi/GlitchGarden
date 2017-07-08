using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D collider) {
		if (collider.GetComponent<Attacker> ()) {
			GetComponent<Animator> ().SetTrigger("isAttacked");
		}
	}
}
