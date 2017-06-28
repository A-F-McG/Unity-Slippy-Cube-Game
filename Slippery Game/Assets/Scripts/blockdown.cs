using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockdown : MonoBehaviour {

	private Animation anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation> ();
		StartCoroutine (spiking());
	}

	IEnumerator spiking(){
		while (true) {
			anim.Play ();
			yield return new WaitForSeconds (3f);
		}
	}

}
