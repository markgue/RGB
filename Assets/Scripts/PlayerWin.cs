﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour {

	public GameObject winFireworks;
	public GameObject winThing; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		Instantiate(winFireworks, gameObject.transform.position, Quaternion.identity);
		Instantiate(winFireworks, Vector2(18.0f, 1.0f), Quaternion.identity);
	}
}
