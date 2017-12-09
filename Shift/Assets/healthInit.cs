using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt("hp", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
