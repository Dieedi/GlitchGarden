using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	[Tooltip ("Max attackers on start")]
	public int maxAttacker;
	[Tooltip ("Delay before increasing maxAttackers")]
	public float maxAttackerChangeDelay;
	[Tooltip ("Number of Attacker to add after each period given by maxAttackerChangeDelay")]
	public int maxAttackerToAddEachTime;

	public GameObject[] attackerPrefabs;
	public GameObject[] SpawnerLines;
	// attackersOnBoard has to be accessible by HealthController  Die () method
	public static int attackersOnBoard = 0;

	private GameObject Parent;
	private float timer = 0f;
	private bool[] spawnInLines;

	void Start () {
		spawnInLines = new bool[SpawnerLines.Length];
		for (int i = 0; i < SpawnerLines.Length; i++) {
			spawnInLines [i] = false;
		}
	}
		
	// Update is called once per frame
	void Update () {
		int randomLine = Random.Range (0, SpawnerLines.Length);
		int randomAttacker = Random.Range (0, attackerPrefabs.Length);

		timer += Time.deltaTime;
		if (timer >= maxAttackerChangeDelay) {
			maxAttacker += maxAttackerToAddEachTime;
			timer = 0;
		}

		if (!LineWaitingForSpawn (randomLine) && attackersOnBoard <= maxAttacker) {
			// Attacker is going to spawn -> add Attacker on board
			attackersOnBoard++;
			IEnumerator spawnAttacker = SpawnAttacker (randomLine, randomAttacker);
			StartCoroutine (spawnAttacker);
		}
	}

	IEnumerator SpawnAttacker (int line, int attacker) {
		GameObject currentAttacker = attackerPrefabs [attacker];

		float timeToWait = currentAttacker.GetComponent<Attacker> ().seenEveryXSeconds;

		yield return new WaitForSeconds (timeToWait);
		Spawn (currentAttacker, line);
	}

	bool LineWaitingForSpawn(int line) {
		if (spawnInLines [line] == false) {
			spawnInLines [line] = true;
			return false;
		} else {
			spawnInLines [line] = false;
			return true;
		}
	}

	void Spawn (GameObject Attacker, int line) {		
		GameObject newAttacker = Instantiate (Attacker, SpawnerLines [line].transform.position, Quaternion.identity);
		newAttacker.transform.parent = SpawnerLines [line].transform;
	}
}
