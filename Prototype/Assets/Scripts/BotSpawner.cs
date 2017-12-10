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

	// Use this for initialization
	public void Start () {
		myRB = GetComponent<Rigidbody> ();
		Invoke("SpawnEnemies", 0.0f);
	}

	// Update is called once per frame
	void Update () 
	{	
		timer += Time.deltaTime;
		if (timer > 10) 
		{
			SpawnEnemies ();
			timer = 0;
		}
	}

	public void SpawnEnemies()
	{
		i = Random.Range (2, 3);
		for (int w=1;  w < i; w++)
		{
			for (int t=0; t < 3; t++)
			{
				d = Random.Range (1, 3);
				switch (d) {
				case 0:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (-14, 14), 0);
					Instantiate (bot, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				case 1:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (-14, 14), 0);
					Instantiate (bot2, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				case 2:
					spawnL = new Vector3 (myRB.position.x + 10, Random.Range (-14, 14), 0);
					Instantiate (bot2, spawnL, Quaternion.Euler (0, 270, 0));
					break;
				}
			}
		}
	}
}
