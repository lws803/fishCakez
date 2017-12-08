using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public int columns;
	public int rows;
	public GameObject[] floorTiles;
	public GameObject[] wallTiles;

	void BoardSetup () {
		for (int x = -1; x < columns + 1; x++) {
			for (int y = -1; y < rows + 1; y++) {

			}
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
