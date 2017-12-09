using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneBullet : MonoBehaviour {

	Rigidbody2D myBody;

	public float range;
	public float maxSpeed;
	public int hp = 3,maxHP = 3;

	//public GameObject dissipateParticle;

	// Use this for initialization
	void Start () {
		myBody = this.GetComponent<Rigidbody2D> ();
		Destroy (this.gameObject, range);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D collision) 
	{
		Vector3 destroyedPos = this.transform.position;

		//Instantiate (dissipateParticle, destroyedPos, Quaternion.identity);

		maxSpeed = 0;

		if (collision.gameObject.CompareTag ("PlayerWall")) {
			//Collection of items
			//Destroy(other.gameObject, timeToDestroyPlayer);

			print("bullet collided with PlayerWall");

		}

		Destroy (this.gameObject);
	}
}
