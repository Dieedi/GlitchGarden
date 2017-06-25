using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LevelManager))]
public class SplashSoundController : MonoBehaviour {

	public GameObject Fader;

	private FadeController fader;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		fader = Fader.GetComponent<FadeController> ();
	}

	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			fader.LoadNextLevel ();
		}
	}
}
