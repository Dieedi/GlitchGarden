using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject Fader;

	void Start () {
		
	}

	void Update () {
		print ("hop");
	}

	// Use this for initialization
	public void LoadLevel (string name) {
	}

	public void QuitRequest () {
		// not good for phone app !!!!
		Application.Quit();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
