using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	
	public Rigidbody2D bullet;
	public float maxSpeed = 25f;
	public Transform firePos;
	public float fireRange;
	public Transform player;

	//public ParticleSystem muzzleFlash;
	// Use this for initialization
	void Start () {
		InvokeRepeating("fire", 2.0f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		//fire ();
	}

	void fire () {
		if (Mathf.Sqrt (Mathf.Pow ((this.transform.position.x - player.position.x), 2) + Mathf.Pow ((this.transform.position.y - player.position.y), 2)) < fireRange) {
			Rigidbody2D bulletInstance = Instantiate(bullet, firePos.position,Quaternion.Euler(0,0,0)) as Rigidbody2D;
			bulletInstance.velocity = firePos.right * maxSpeed;
		}

	}
		
}
