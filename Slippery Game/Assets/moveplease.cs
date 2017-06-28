using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplease : MonoBehaviour {

	private Rigidbody cube;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		cube = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float left = Input.acceleration.x;
		Vector3 move = new Vector3 (left, 0.0f, 0.0f);
		cube.AddForce (move*moveSpeed*Time.deltaTime);
	}
}
