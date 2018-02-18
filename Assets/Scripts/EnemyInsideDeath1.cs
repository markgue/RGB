using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInsideDeath1 : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			if(other.GetComponent<PlayerController>().isDead != true )
				Destroy (gameObject);
		}
	}
	
}
