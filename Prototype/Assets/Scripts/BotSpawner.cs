using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSpawner : MonoBehaviour {

	public enum spawnState {waiting, spawning, counting}

	[System.Serializable]
	public class Wave
	{
		public string name;
		public Transform enemy;
		public int count;
		public float rate;
	}

	public Wave[] waves;
	private int nextWave = 0;

	public Transform[] spawnPoints;

	public spawnState state = spawnState.counting;

	public float timeBetweenWaves = 2.5f;
	public float waveCountdown;

	private float searchCountdown = 1;

	void Start()
	{
		waveCountdown = timeBetweenWaves;
	}
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
        i = Random.Range(5, 10);
        if (timer > i)
        {
            for (int t = 0; t < 2; t++)
            {
                d = Random.Range(1, 2);
                switch (d) {
                    case 0:
                        spawnL = new Vector3(myRB.position.x + Random.Range(15, 50), Random.Range(-14, 14), 0);
                        Instantiate(bot, spawnL, Quaternion.Euler(0, 270, 0));
                        break;
                    case 1:
                        spawnL = new Vector3(myRB.position.x + Random.Range(15, 50), Random.Range(-14, 14), 0);
                        Instantiate(bot2, spawnL, Quaternion.Euler(0, 270, 0));
                        break;
                }
            }

            spawnL = new Vector3(myRB.position.x + Random.Range(15, 50), Random.Range(-14, 14), 0);
            Instantiate(bot, spawnL, Quaternion.Euler(0, 270, 0));
            spawnL = new Vector3(myRB.position.x + Random.Range(15, 50), Random.Range(-14, 14), 0);
            Instantiate(bot, spawnL, Quaternion.Euler(0, 270, 0));
            spawnL = new Vector3(myRB.position.x + Random.Range(15, 50), Random.Range(-14, 14), 0);
            Instantiate(bot, spawnL, Quaternion.Euler(0, 270, 0));
            timer = 0.0f;
        }
    }
            
	void Update()
	{

		if (state == spawnState.waiting)
		{
			if (!anyEnemies ()) {
				newWave ();
			} 
			else
			{
				return;
			}
		}
		if (waveCountdown <= 0) 
		{
			if (state != spawnState.spawning) 
			{
				StartCoroutine (spawnWave (waves[nextWave]));
			}
		} 
		else 
		{
			waveCountdown -= Time.deltaTime;
		}
	}

	void newWave()
	{
		state = spawnState.counting;

		waveCountdown = timeBetweenWaves;

		if (nextWave + 1 > waves.Length - 1) {
			nextWave = 0;
		}
		else
		{
			nextWave++;
		}
	}

	bool anyEnemies()
	{
		searchCountdown -= Time.deltaTime;
		if (searchCountdown <= 0)
		{
			searchCountdown = 1f;
			if (GameObject.FindGameObjectWithTag ("enemy") == null)
			{
				return false;
			} 
		}
		return true;
	}

	IEnumerator spawnWave(Wave _wave)
	{
		state = spawnState.spawning;

		for (int i = 0; i < _wave.count; i++) 
		{
			spawnEnemy (_wave.enemy);

			yield return new WaitForSeconds (1f / _wave.rate);
		}

		state = spawnState.waiting;

		yield break;
	}

	void spawnEnemy (Transform _enemy)
	{
		Transform _sp = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate (_enemy, _sp.position, Quaternion.Euler (0, 270, 0));
	}
}