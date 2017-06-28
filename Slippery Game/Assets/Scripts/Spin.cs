using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public int spinx,spiny,spinz;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (spinx, spiny, spinz);
	}
}
