using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour {

	public GameObject bot;
	public GameObject bot2;

	Rigidbody myRB;

	Vector3 spawnL;

	float timer;
	float i;
	int d;
	float x;
	float y;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		SpawnEnemies ();
	}

	void SpawnEnemies()
	{
		timer += Time.deltaTime;
		i = Random.Range (5, 10);
		if (timer > i)
		{
			for (int t=0; t < 2; t++)
			{
				d = Random.Range (1, 2);
				switch (d) {
				case 0:
					spawnL = new Vector3 (myRB.position.x + Random.Range(15,50), Random.Range (-14, 14), 0);
					Instantiate (bot, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				case 1:
					spawnL = new Vector3 (myRB.position.x + Random.Range(15,50), Random.Range (-14, 14), 0);
					Instantiate (bot2, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				}
			}

			spawnL = new Vector3(myRB.position.x + Random.Range(15,50), Random.Range(-14, 14), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			spawnL = new Vector3(myRB.position.x + Random.Range(15,50), Random.Range(-14, 14), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			spawnL = new Vector3(myRB.position.x + Random.Range(15,50), Random.Range(-14, 14), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			timer = 0.0f;
		}
	}
}
