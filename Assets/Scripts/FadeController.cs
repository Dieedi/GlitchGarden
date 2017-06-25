using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour {

	public float fadeTimer;
	public Image fadeOutUIImage;
	public enum FadeDirection
	{
		In, //Alpha = 1
		Out // Alpha = 0
	}

	// Use this for initialization
	void Start () {
		fadeOutUIImage = GetComponent<Image> ();
	}

	void OnEnable () {
		// Fade Panel is active at begining so start fade Out
		StartCoroutine(Fade(FadeDirection.Out));
	}

	public IEnumerator Fade(FadeDirection direction) {
		// Fade depending on given Direction
		// Get the good alpha value
		float alpha = (direction == FadeDirection.Out)? 1 : 0;
		float fadeEndValue = (direction == FadeDirection.Out)? 0 : 1;

		if (direction == FadeDirection.Out) {
			while (alpha >= fadeEndValue)
			{
				SetColorImage (ref alpha, direction);
				yield return null;
			}
			// disable the panel
			fadeOutUIImage.enabled = false; 
		} else {
			// active before changing alpha
			fadeOutUIImage.enabled = true; 
			while (alpha <= fadeEndValue)
			{
				SetColorImage (ref alpha, direction);
				yield return null;
			}
		}
	}

	private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
	{
		fadeOutUIImage.color = new Color (fadeOutUIImage.color.r,fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
		alpha += Time.deltaTime / fadeTimer * ((fadeDirection == FadeDirection.Out)? -1 : 1) ;
	}

	public IEnumerator FadeAndLoadScene (string name, int nextScene) {
		// On call, first Fade In, then Load new scene
		yield return Fade (FadeDirection.In);
		if (nextScene == -2) {
			SceneManager.LoadScene (name);
		} else {
			SceneManager.LoadScene(nextScene);
		}
	}

	public void LoadLevel (string name) {
		if (gameObject.activeSelf == false) {
			Debug.LogError ("Fader Desactivé !");
		}
		StartCoroutine (FadeAndLoadScene (name, -2));
	}

	public void LoadNextLevel() {
		if (gameObject.activeSelf == false) {
			Debug.LogError ("Fader Desactivé !");
		}
		StartCoroutine (FadeAndLoadScene ("", SceneManager.GetActiveScene ().buildIndex + 1));
	}
}
