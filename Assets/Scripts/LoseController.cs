using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour {

	public GameObject Robot;
	public Spawner spawner;
	private FadeController fader;

	private bool[] robotAlreaySpawned;

	void Start () {
		robotAlreaySpawned = new bool[spawner.SpawnerLines.Length];
		for (int i = 0; i < robotAlreaySpawned.Length; i++) {
			robotAlreaySpawned [i] = false;
		}
		fader = GameObject.FindObjectOfType<FadeController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (robotAlreaySpawned [(int)collider.transform.position.y - 1] == false) {
			Vector3 newPosition = new Vector3 (transform.position.x - 0.5f, collider.transform.position.y - 0.5f, transform.position.z);
			Instantiate (Robot, newPosition, Quaternion.identity);

			robotAlreaySpawned [(int)collider.transform.position.y - 1] = true;
		} else {
			fader.LoadLevel ("Lose");
		}
	}
}
