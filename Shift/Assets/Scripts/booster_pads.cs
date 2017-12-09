using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster_pads : MonoBehaviour {
	public GameObject boss;
	// Use this for initialization
	void Start () {
		boss = GameObject.Find("boss_turret");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D (Collision2D collision)  {
		if (collision.gameObject.CompareTag ("Player")) {
			boss.GetComponentInParent<enemy_damage> ().hp -= 1;
			spawnPad ();
			Destroy (this.gameObject);
		}

	}

	void spawnPad () {
		int point;
		point = Random.Range (1, 4);
		Vector3 thisPoint;
		switch (point) {
			case 1:
			thisPoint = new Vector3 (-7, 12, -0.1209252f);
			Instantiate (this, thisPoint, Quaternion.identity);
			break;
			case 2:
			thisPoint = new Vector3 (7, 12, -0.1209252f);
			Instantiate (this, thisPoint, Quaternion.identity);
			break;
			case 3:
			thisPoint = new Vector3 (7, 0, -0.1209252f);
			Instantiate (this, thisPoint, Quaternion.identity);
			break;
			case 4:
			thisPoint = new Vector3 (-7, 0, -0.1209252f);
			Instantiate (this, thisPoint, Quaternion.identity);
			break;
		}
	}
}
