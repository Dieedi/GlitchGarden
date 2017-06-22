using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(LevelManager))]
public class SplashSoundController : MonoBehaviour {

	private LevelManager levelManager;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying) {
			levelManager.LoadNextLevel ();
		}
	}
}
