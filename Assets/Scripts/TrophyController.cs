using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour {

	public GameObject Star;
	public GameObject TrophyTop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PopOutStar () {
		Transform star = TrophyTop.GetComponentInChildren<Transform> ();
		GameObject StarOut = Instantiate (Star, star.position, Quaternion.identity);
		StarOut.transform.parent = TrophyTop.transform.parent;
	}
}
