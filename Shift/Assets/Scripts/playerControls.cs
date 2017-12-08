using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour {

	public float speed;				//Floating point variable to store the player's movement speed.

	Vector3 pos;
	Transform tr;

	// Use this for initialization
	void Start()
	{
		pos = transform.position;
		tr = transform;
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.D) && tr.position == pos)
		{
			pos += Vector3.right;
		}
		else if (Input.GetKey(KeyCode.A) && tr.position == pos)
		{
			pos += Vector3.left;
		}
		else if (Input.GetKey(KeyCode.W) && tr.position == pos)
		{
			pos += Vector3.up;
		}
		else if (Input.GetKey(KeyCode.S) && tr.position == pos)
		{
			pos += Vector3.down;
		}

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);


	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) 
		{
			// Dump in some collder code here
		}


	}


}
