using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour {



	AudioSource audio;
	// Use this for initialization
	void Start () {
		
		audio = GetComponent<AudioSource> ();

	


		PlaySound ();
	}


	void PlaySound(){
		audio.Play ();
	}
}
