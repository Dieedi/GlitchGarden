using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private AudioSource winSound;
	private float timePassed;
	private Slider slider;
	private FadeController fader;
	private bool endGameLoaded = false;
	private Spawner spawner;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		fader = GameObject.FindObjectOfType<FadeController> ();
		winSound = GetComponent<AudioSource> ();
		spawner = GameObject.FindObjectOfType<Spawner> ();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value += Time.deltaTime;

		if (slider.value >= slider.maxValue && !endGameLoaded) {
			LevelEnded ();
			endGameLoaded = true;
		}

		if (endGameLoaded && !winSound.isPlaying) {
			fader.LoadLevel ("Win");
		}
	}

	void LevelEnded () {
		DestroyAttackers ();
		winSound.time = 1.8f;
		winSound.Play ();
	}

	void DestroyAttackers () {
		Attacker[] attackers = GameObject.FindObjectsOfType<Attacker> ();
		foreach (Attacker attacker in attackers) {
			Destroy (attacker.gameObject);
		}
		spawner.StopAllCoroutines ();
		spawner.maxAttacker = 0;
		spawner.maxAttackerToAddEachTime = 0;
	}
}
