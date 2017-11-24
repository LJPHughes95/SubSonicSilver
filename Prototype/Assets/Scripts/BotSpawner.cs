using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour {

	public GameObject bot;
	public GameObject bot2;
	public GameObject bot3;

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
				d = Random.Range (1, 3);
				switch (d) {
				case 0:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (x, y), 0);
					Instantiate (bot, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				case 1:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (x, y), 0);
					Instantiate (bot2, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				case 2:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (x, y), 0);
					Instantiate (bot3, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				}

				x = y + 1;
				y += 7;

			}

			spawnL = new Vector3(myRB.position.x + 10, Random.Range(4, 10), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			spawnL = new Vector3(myRB.position.x + 10, Random.Range(11, 17), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			spawnL = new Vector3(myRB.position.x + 10, Random.Range(18, 24), 0);
			Instantiate(bot, spawnL, Quaternion.Euler(0,270,0));
			timer = 0.0f;
		}
	}
}
