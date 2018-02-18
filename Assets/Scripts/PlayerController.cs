using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int moveSpeed; 
	public int jumpSpeed;
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;
	public GameObject respawnPoint; 
	public GameObject deathEffect; 

	public Animator animator; 
	public bool isDead = false; 

	Rigidbody2D rb;

	private bool isGrounded;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> (); 
	}
	
	// Update is called once per frame
	void Update () {
		
		detectJump ();
		detectMove (); 
 
		transform.rotation = Quaternion.Euler (0, 0, 0);


		if (!isGrounded) {
			animator.SetBool ("Moving", false);
		} else if (rb.velocity.x > 1) {
			animator.SetBool ("Moving", true);
			animator.SetBool ("Facing_Right", true); 
		} else if (rb.velocity.x < -1) {
			animator.SetBool ("Moving", true);
			animator.SetBool ("Facing_Right", false); 
		} else {
			animator.SetBool ("Moving", false);
		}
	}

	void detectMove(){
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity = new Vector2 (-moveSpeed, rb.velocity.y);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.LeftArrow)) {
			rb.velocity  = new Vector2 (moveSpeed, rb.velocity.y);
		}
	
	}
	void detectJump(){
		if(Input.GetButton("Jump")) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed);
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
