using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//default moving speed set to 5
	public float movementSpeed;
	private float currentMoveSpeed;
	public float diagonalMoveModifier;
	//diagonalMoveModifier is ~3/4.
	
	//Accessing animator
	private Animator anim;
	//fixes bouncing when colllision happens
	private Rigidbody2D playerRB;	

	//is true when player is moving
	private bool playerMoving;
	//Holds last X & Y value
	public Vector2 lastMove;

	//make sure no player duplictaion
	private static bool playerExists;

	//for attack animations and duration between attacks.
	public bool attacking;
	public float attackTime;
	private float attackTimeCounter;

	public string startPoint;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator>();
		playerRB = GetComponent<Rigidbody2D> ();

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//default state of moving
		playerMoving = false;

		if (!attacking) {
			//Move Right and Left
			if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * movementSpeed * Time.deltaTime, 0f, 0f));
				playerRB.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, playerRB.velocity.y);
				playerMoving = true;
				lastMove = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			//Move Up and Down
			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * movementSpeed * Time.deltaTime, 0f));
				playerRB.velocity = new Vector2 (playerRB.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector2 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				playerRB.velocity = new Vector2 (0f, playerRB.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				playerRB.velocity = new Vector2 (playerRB.velocity.x, 0f);
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				attackTimeCounter = attackTime;
				attacking = true;
				playerRB.velocity = Vector2.zero;
				anim.SetBool ("PlayerAttack", true);
			}
			if(Mathf.abs(Input.GetAxisRaw("Horizontal") > 0.5f && Mathf.abs(Input.GetAxisRaw("Vertical") > 0.5f){
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			} else {currentMoveSpeed = moveSpeed;}
		}
			if (attackTimeCounter > 0) {
		
				attackTimeCounter -= Time.deltaTime;
			}

			if (attackTimeCounter <= 0) {
				attacking = false;
				anim.SetBool ("PlayerAttack", false);
			}
		//sets Variables MoveX and MoveY for the animations
		anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);
	}
}
