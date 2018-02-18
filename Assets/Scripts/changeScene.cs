using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("return") || Input.GetKeyDown ("enter")) {
			SceneManager.LoadScene ("rgbgame"); //CHange to the first scene of the game

		}
	}
}
