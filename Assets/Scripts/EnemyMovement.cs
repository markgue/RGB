using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float moveSpeed; 
	public bool moveRight; 

	public GameObject leftestPoint; 
	public GameObject rightestPoint; 
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, 0, 0);

		if (transform.position.x >= rightestPoint.transform.position.x-1)
			moveRight = false; 
		if (transform.position.x <= leftestPoint.transform.position.x+1)
			moveRight = true; 

		if (moveRight) {
			//transform.localScale = new Vector3 (-1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		} else {
			//transform.localScale = new Vector3 (1f, 1f, 1f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}
	}
}
