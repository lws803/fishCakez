using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_damage : MonoBehaviour {
	public GameObject redBar;
	public Canvas GameOver;
	public int hp = 10, maxHP = 10;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
		if (hp == 0) {
			GameOver.gameObject.SetActive (true);
			Time.timeScale = 0;
		}
		float widthSize = ((float)hp / maxHP) * 3f;
		redBar.transform.localScale = new Vector2 (widthSize, redBar.transform.localScale.y);
	}


	void damage_health () {
		hp -= 1;
	}
}
