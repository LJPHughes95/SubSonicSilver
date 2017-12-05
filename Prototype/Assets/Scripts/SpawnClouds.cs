using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClouds : MonoBehaviour {

	public GameObject cloud;
	public GameObject cloud2;
	public GameObject cloud3;
	public GameObject cloud4;
	public GameObject cloud5;
	public GameObject cloud6;
	public GameObject cloud7;
	public GameObject cloud8;

	Vector3 CSpawn;

	int d;
	int noOfClouds;

	// Use this for initialization
	void Start () {
		noOfClouds = Random.Range (15, 20);
		for (int i = 0; i < noOfClouds; i++) {
			d = Random.Range (1, 8);
			switch (d) {
			case 0:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 70), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud, CSpawn, Quaternion.identity);
				break;
			case 1:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 50), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud2, CSpawn, Quaternion.identity);
				break;
			case 2:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 80), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud3, CSpawn, Quaternion.identity);
				break;
			case 3:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 20), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud4, CSpawn, Quaternion.identity);
				break;
			case 4:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 10), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud5, CSpawn, Quaternion.identity);
				break;
			case 5:
				CSpawn = new Vector3 (transform.position.x, Random.Range (9, 19), transform.position.z);
				Instantiate (cloud6, CSpawn, Quaternion.identity);
				break;
			case 6:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 50), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud7, CSpawn, Quaternion.identity);
				break;
			case 7:
				CSpawn = new Vector3 (Random.Range ((transform.position.x - 100), transform.position.x), Random.Range (9, 19), transform.position.z);
				Instantiate (cloud8, CSpawn, Quaternion.identity);
				break;
			}
		}

	}
		public void SpawnMoreClouds ()
		{
			noOfClouds = Random.Range (15, 20);
			for (int i = 0; i < noOfClouds; i++)
			{
				d = Random.Range (1, 8);
				switch (d) {
				case 0:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 70),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud, CSpawn, Quaternion.identity);
					break;
				case 1:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 50), transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud2, CSpawn, Quaternion.identity);
					break;
				case 2:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 80),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud3, CSpawn, Quaternion.identity);
					break;
				case 3:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 20),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud4, CSpawn, Quaternion.identity);
					break;
				case 4:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 10),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud5, CSpawn, Quaternion.identity);
					break;
				case 5:
					CSpawn = new Vector3 (transform.position.x, Random.Range (9, 19), transform.position.z);
					Instantiate (cloud6, CSpawn, Quaternion.identity);
					break;
				case 6:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 50),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud7, CSpawn, Quaternion.identity);
					break;
				case 7:
					CSpawn = new Vector3 (Random.Range((transform.position.x - 100),transform.position.x), Random.Range (9, 19), transform.position.z);
					Instantiate (cloud8, CSpawn, Quaternion.identity);
					break;
				}
			}
	}

}
