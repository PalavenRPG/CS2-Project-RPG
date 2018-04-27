using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	//follows the current Target
	public GameObject followTarget;
	//gets the pos of the target
	private Vector3 targetPos;
	//speed that the Camera follows the target.
	public float chaseSpeed;
	//prevents duplicate Camera
	private static bool cameraExists;
	// Use this for initialization
	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} 
		else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, chaseSpeed * Time.deltaTime);
	}
}
