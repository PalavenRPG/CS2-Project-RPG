using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GavionTalks : MonoBehaviour {
	private Animator anim;
	private bool isTalkedTo;
	private Rigidbody2D GavionRigidBody;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		GavionRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Talking",isTalkedTo);
	}

	void OnTriggerEnter2D(Collider2D player){

		if (player.gameObject.name == "Player_0") {
			isTalkedTo = true;
			//	talking ();
		} else {
			isTalkedTo = false;
		}
	}

	void talking(){
	
	}
}
