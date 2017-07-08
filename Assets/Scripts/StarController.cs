using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarController: MonoBehaviour {
	
	public int starValuePoint;

	private StarCountController starCount;

	// Use this for initialization
	void Start () {
		starCount = GameObject.FindObjectOfType<StarCountController> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
		print ("add star");
		starCount.AddStars (starValuePoint);
		Destroy (this.gameObject);
	}
}
