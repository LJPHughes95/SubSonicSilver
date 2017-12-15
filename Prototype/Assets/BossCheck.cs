using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCheck : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Boss") == null)
		{
			SceneManager.LoadScene (0);
		} 
	}
}
