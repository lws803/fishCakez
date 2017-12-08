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
		float widthSize = (currentHP / maxHP) * 565.85f;
		redBar.sizeDelta = new Vector2 (widthSize, 108.7f);
	}

	public void damaged(float amount){
		currentHP -= amount;
	}

	public void heal(float amount){
		currentHP += amount;
	}
}
