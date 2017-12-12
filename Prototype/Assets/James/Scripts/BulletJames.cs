using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJames : MonoBehaviour {


    public int projDirection;
    public float speed;

    public GameObject ExplosionGo;


    // Use this for initialization
    void Start()
    {
        projDirection = PlayerController.playerInstance.GetDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += new Vector3(projDirection * speed, 0.0f, 0.0f);

        Destroy(gameObject, 2.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            PlayExplosion();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);

        //plays the explosion where the bullet touches the enemy
        explosion.transform.position = transform.position;
    }

    /*void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Boss" && health <= 0){
			explosion.ChangeImage();
			Destroy (collision.gameObject);
			Destroy (gameObject);
		}
	}
	*/
}
