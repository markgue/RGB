using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int moveSpeed; 
	public int jumpSpeed;  
	public GameObject respawnPoint; 
	public GameObject deathEffect; 

	public Animator animator; 
	public bool isDead = false; 

	private bool isGrounded; 
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, 0, 0);
		detectMove (); 
		detectJump (); 
		if (!isGrounded) {
			animator.SetBool ("Moving", false);
		} else if (GetComponent<Rigidbody2D> ().velocity.x > 1) {
			animator.SetBool ("Moving", true);
			animator.SetBool ("Facing_Right", true); 
		} else if (GetComponent<Rigidbody2D> ().velocity.x < -1) {
			animator.SetBool ("Moving", true);
			animator.SetBool ("Facing_Right", false); 
		} else{
			animator.SetBool ("Moving", false);
		}
	}

	void detectMove(){
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D>().velocity  = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
	
	}
	void detectJump(){
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.UpArrow)) {
			if (isGrounded) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpSpeed);
				isGrounded = false; 
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			RespawnPlayer ();
		} 

	}
	void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo"); 

	}

	public IEnumerator RespawnPlayerCo(){
		
		GetComponent<Renderer> ().enabled = false;
		Instantiate(deathEffect, gameObject.transform.position, Quaternion.identity);
		isDead = true; 

		yield return new WaitForSeconds(2);

		gameObject.transform.position = respawnPoint.transform.position;
		GetComponent<Renderer> ().enabled = true;
		isDead = false; 
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			isGrounded = true;
		}
	}



}
