using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOutsideDeath : MonoBehaviour {

	// Use this for initialization
	public string outsideColor; 
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (outsideColor == "Red" && Input.GetKeyDown(KeyCode.Z))
		{
			Destroy (gameObject);
		}
		if (outsideColor == "Green" &&Input.GetKeyDown(KeyCode.X))
		{
			Destroy (gameObject);
		}
		if (outsideColor == "Blue" &&Input.GetKeyDown(KeyCode.C))
		{
			Destroy (gameObject);
		}
	}

}
