using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {


	private Vector3 moving;
	public float moveSpeed;

	private Rigidbody cube;
	public float cubeSpeed;
	public GameManager manager;



	//Tokens
	public GameObject coinsparent;
	private int coinsparentcount;
	private int cointcount;

	private Vector3 spawn;

	public AudioClip[] audioClip;
	AudioSource audio;

	private int dieCount=0;

	Matrix4x4 calibrationMatrix;


	void calibrateAccelerometer(){
		Vector3 wantedDeadZone = Input.acceleration;
		Quaternion rotateQuaternion = Quaternion.FromToRotation (new Vector3 (0f, -1f, -1f), wantedDeadZone);
		Matrix4x4 matrix = Matrix4x4.TRS(Vector3.zero, rotateQuaternion, new Vector3(1f,1f,1f));
		this.calibrationMatrix=matrix.inverse;
	}
	Vector3 getAccelerometer(Vector3 accelerator){
		Vector3 accel = this.calibrationMatrix.MultiplyVector (accelerator);
		return accel;
	}








	// Use this for initialization
	void Start () {
		calibrateAccelerometer ();

		audio = GetComponent<AudioSource> ();
		coinsparentcount = coinsparent.transform.childCount;
		cube = gameObject.GetComponent<Rigidbody> ();
		spawn = transform.position;
		manager = manager.GetComponent<GameManager> ();
		cointcount = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 _InputDir = getAccelerometer (Input.acceleration);
		float left = _InputDir.x;
		float up = _InputDir.y - _InputDir.z;
		Vector3 move = new Vector3 (left, 0.0f, up);
		cube.AddForce(move*cubeSpeed*Time.deltaTime);

		if (transform.position.y<-3)
		{
			dieCount += 1;
			Die ();
			if (dieCount > 2 && SceneManager.GetActiveScene().name != "Level World") {
				cointcount = 0;
				audio.PlayOneShot (audioClip[3], 0.7F);
				manager.diedLevel ();
			}
		}
}
	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "enemy") 
		{
			dieCount += 1;
		if (dieCount < 3) {
			Die ();

		} else {
				cointcount = 0;
				audio.PlayOneShot (audioClip[3], 0.7F);
				manager.diedLevel();
		}

	}
	}



	private int currentScene;
		
	public Texture image;
	private int livesLeft;
	public GUISkin coinscountSkin;
	private int defaultResolutionHeight;
	private int defaultFontSizelabel;


	void OnGUI(){
		GUI.skin = coinscountSkin;
		defaultResolutionHeight=320; // assume that you designed all your GUIs using 480p height...

		defaultFontSizelabel=15;

		GUI.skin.label.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizelabel; // ...then

		if (SceneManager.GetActiveScene().name != "Level World"){

			livesLeft = 3 - dieCount;
			GUI.Label (new Rect (Screen.width/48, Screen.height/8, Screen.width/4, Screen.height/2), cointcount.ToString () + "/" + coinsparentcount.ToString () + " coins collected");

			if (livesLeft == 3) {
				GUI.DrawTexture (new Rect (Screen.width-(Screen.width/12)*3, Screen.height/8, Screen.width/16, Screen.height/11), image);
				GUI.DrawTexture (new Rect (Screen.width-(Screen.width/12)*2, Screen.height/8, Screen.width/16, Screen.height/11), image);
				GUI.DrawTexture (new Rect (Screen.width-Screen.width/12, Screen.height/8, Screen.width/16, Screen.height/11), image);
			}
			if (livesLeft == 2) {
				GUI.DrawTexture (new Rect (Screen.width-(Screen.width/12)*3, Screen.height/8, Screen.width/16, Screen.height/11), image);
				GUI.DrawTexture (new Rect (Screen.width-(Screen.width/12)*2, Screen.height/8, Screen.width/16, Screen.height/11), image);
		
			}
			if (livesLeft == 1) {
				GUI.DrawTexture (new Rect (Screen.width-(Screen.width/12)*3, Screen.height/8, Screen.width/16, Screen.height/11), image);
		
		}
		}
	}


		
	public void saveStarsLevel1(){
		if (SceneManager.GetActiveScene().name == "1"){
		if (cointcount > PlayerPrefs.GetInt ("Stars for level 1")) {
			PlayerPrefs.SetInt ("Stars for level 1", cointcount);
		}
		PlayerPrefs.GetInt ("Stars for level 1");
	}
		if (SceneManager.GetActiveScene().name == "2"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 2")) {
				PlayerPrefs.SetInt ("Stars for level 2", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 2");
		}
		if (SceneManager.GetActiveScene().name == "3"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 3")) {
				PlayerPrefs.SetInt ("Stars for level 3", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 3");
		}
		if (SceneManager.GetActiveScene().name == "4"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 4")) {
				PlayerPrefs.SetInt ("Stars for level 4", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 4");
		}
		if (SceneManager.GetActiveScene().name == "5"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 5")) {
				PlayerPrefs.SetInt ("Stars for level 5", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 5");
		}
		if (SceneManager.GetActiveScene().name == "6"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 6")) {
				PlayerPrefs.SetInt ("Stars for level 6", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 6");
		}
		if (SceneManager.GetActiveScene().name == "7"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 7")) {
				PlayerPrefs.SetInt ("Stars for level 7", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 7");
		}
		if (SceneManager.GetActiveScene().name == "8"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 8")) {
				PlayerPrefs.SetInt ("Stars for level 8", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 8");
		}
		if (SceneManager.GetActiveScene().name == "9"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 9")) {
				PlayerPrefs.SetInt ("Stars for level 9", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 9");
		}
		if (SceneManager.GetActiveScene().name == "10"){
			if (cointcount > PlayerPrefs.GetInt ("Stars for level 10")) {
				PlayerPrefs.SetInt ("Stars for level 10", cointcount);
			}
			PlayerPrefs.GetInt ("Stars for level 10");
		}


	}

	public GameObject spot;
	public GameObject spot1;
	public GameObject spot2;
	public GameObject spot3;

	void OnTriggerEnter(Collider other)
	{
		livesLeft = 3 - dieCount;
		if (other.transform.tag=="goal")
		{
			saveStarsLevel1 ();
			manager.completeLevel ();
			audio.PlayOneShot (audioClip [1], 0.7F);


				
		}
		if (other.transform.tag == "spikes") {
				dieCount += 1;
				if (dieCount <= 3) {
					Die ();

				} else {
					manager.diedLevel();
				}
					
		}
		if (other.transform.tag == "coins") {
			cointcount++;
			audio.PlayOneShot (audioClip[0], 0.7F);
			Destroy (other.gameObject);
		}

		if (other.transform.tag == "transport") {
			audio.PlayOneShot (audioClip[2], 0.7F);
			transform.position = spot.transform.position;
		}
		if (other.transform.tag == "transport1") {
			audio.PlayOneShot (audioClip[2], 0.7F);
			transform.position = spot1.transform.position;
		}
		if (other.transform.tag == "transport2") {
			audio.PlayOneShot (audioClip[2], 0.7F);
			transform.position = spot2.transform.position;
		}
		if (other.transform.tag == "transport3") {
			audio.PlayOneShot (audioClip[2], 0.7F);
			transform.position = spot3.transform.position;
		}

	}

	void Die()
	{
		cube.velocity = Vector3.zero;
		audio.PlayOneShot (audioClip[3], 0.7F);
		transform.position = spawn;
	}


		

}
