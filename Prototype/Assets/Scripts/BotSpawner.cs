using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

		//if (nextWave + 1 > waves.Length - 1) {
  //          Debug.Log(waves.Length);
		//	nextWave = 0;
  //      }
        if(nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("entered");
            SceneManager.LoadScene(2);
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
		Instantiate (_enemy, new Vector3(_sp.position.x,Random.Range(-13,13),_sp.position.z), Quaternion.Euler (0, 270, 0));
	}
}