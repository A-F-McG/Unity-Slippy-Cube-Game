using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour {

	public Transform[] platformposition;
	private int currentposition;
	public float moveSpeed;

	// Use this for initialization
	void Start () {
		transform.position = platformposition [0].position;
		currentposition = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position == platformposition[currentposition].position) {
			currentposition+=1;

		}
		if (currentposition >= platformposition.Length) {
			currentposition = 0;
		}
		transform.position = Vector3.MoveTowards (transform.position, platformposition [currentposition].position, moveSpeed * Time.deltaTime);
	}

}
