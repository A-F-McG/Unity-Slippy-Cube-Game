using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transporterrotation : MonoBehaviour {

	public int spinx, spiny, spinz;
	public GameObject spot;

	// Use this for initialization
	void Update () {
		transform.Rotate (spinx, spiny, spinz);
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Player"){
			print ("hit transporter");
			other.transform.position = spot.transform.position;
		}
	
}
}
