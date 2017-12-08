using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {
	public Canvas pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)){
			if (pauseMenu.gameObject.activeInHierarchy == false) {
				pauseMenu.gameObject.SetActive(true);
				Time.timeScale = 0;
			} 
			else {
				pauseMenu.gameObject.SetActive(false);
				Time.timeScale = 1;
			}
		}
	}
}
