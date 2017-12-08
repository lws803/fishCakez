﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerControls : MonoBehaviour {

	Animator animator;
	public Canvas GameOver;

	public float speed;				//Floating point variable to store the player's movement speed.
	public float gridSize;
	public GameObject redBar;
	public LayerMask mask;

	Vector3 pos;
	public int hp = 3,maxHP = 3;
	//Transform tr;
	//bool collided = false; 

	// Use this for initialization
	void Start()
	{
		hp = 3;
		pos = transform.position;
		//tr = transform;
		animator = this.GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		//====RayCasts====//
		RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, gridSize, mask.value);
		RaycastHit2D hitdown = Physics2D.Raycast(transform.position, Vector2.down, gridSize, mask.value);
		RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, gridSize, mask.value);
		RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, gridSize, mask.value);
		//==Inputs==//
		if (Input.GetKey(KeyCode.A) && transform.position == pos && hitleft.collider  == null)
		{           //(-1,0)
			pos += Vector3.left * gridSize;// Add -1 to pos.x
			animator.SetInteger("Direction", 1);
		}
		if (Input.GetKey(KeyCode.D) && transform.position == pos && hitright.collider == null)
		{           //(1,0)
			pos += Vector3.right * gridSize;// Add 1 to pos.x
			animator.SetInteger("Direction", 3);

		}
		if (Input.GetKey(KeyCode.W) && transform.position == pos && hitup.collider == null)
		{           //(0,1)
			pos += Vector3.up * gridSize; // Add 1 to pos.y
			animator.SetInteger("Direction", 2);

		}
		if (Input.GetKey(KeyCode.S) && transform.position == pos && hitdown.collider  == null)
		{           //(0,-1)
			pos += Vector3.down * gridSize;// Add -1 to pos.y
			animator.SetInteger("Direction", 0);

		}
		//The Current Position = Move To (the current position to the new position by the speed * Time.DeltaTime)
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there

		// Shift stuffs 
		if (Input.GetKeyDown (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			//print ("Doki doki");
			//print (count++);
		}

		if (hp == 0) {
			GameOver.gameObject.SetActive (true);
			Time.timeScale = 0;
		}

		float widthSize = ((float)hp / maxHP) * 1f;
		redBar.transform.localScale = new Vector2 (widthSize, redBar.transform.localScale.y);
	}

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnCollisionEnter2D(Collision2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag ("PickUp")) {
			// Dump in some collder code here
			print ("Pick up detected");
		} else if (other.gameObject.CompareTag ("Water")) {
			hp--;
		} else{
			//collided = true;
		}
		print ("Collided");

	}

}
