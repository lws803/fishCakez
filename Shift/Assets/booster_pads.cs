using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster_pads : MonoBehaviour {
	public GameObject boss;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D collision)  {
		boss.GetComponentInParent<enemy_damage> ().hp -= 1;
		Destroy (this.gameObject);
	}
}
