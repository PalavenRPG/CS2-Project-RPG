using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
	public int damageToGive;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player_0") 
		{
			other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
		}
	}

}
