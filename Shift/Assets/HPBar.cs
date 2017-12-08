using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour {

	public float currentHP;
	public float maxHP;
	public RectTransform redBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float widthSize = (currentHP / maxHP) * 128;
		redBar.sizeDelta = new Vector2 (widthSize, 38.4);
	}

	public void damaged(float amount){
		currentHP -= amount;
	}

	public void heal(float amount){
		currentHP += amount;
	}
}
