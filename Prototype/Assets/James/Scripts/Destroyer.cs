using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void Start()
	{
		Invoke ("Destroy", 0.2f);
	}

	void Destroy()
    {
        Destroy(gameObject);
    }
}
