using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

	float currentHP = GameObject.Find("Player 3").GetComponent<playerControls>().hp;
	float maxHP =3;
	public GameObject redBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float widthSize = (currentHP / maxHP) * 1f;
		redBar.transform.localScale = new Vector2 (widthSize, 0.66f);
	}

	public void damaged(float amount){
		currentHP -= amount;
	}

	public void heal(float amount){
		currentHP += amount;
	}
}
