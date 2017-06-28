using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelworld : MonoBehaviour {

	public int whichLevel;
	private Touch myTouch;
	private string loadPrompt;
	private string loadTrophyPrompt;
	private bool inRange=false;
	private int currentLevel;
	private bool levelCan;
	private string cannot;
	public GameObject padlock;
	private bool levelCann;
	public GameObject deathparticles;
	private bool trophyunlocked=false;


	void Start(){
		
		trophyWon = "You're such a star";
		currentLevel=PlayerPrefs.GetInt("Level Completed");
		levelCann = whichLevel<currentLevel+ 2? true: false;
		levelCan = levelCann && whichLevel <6 ? true : false;
		loadPrompt = "Tap the screen to play level " + whichLevel.ToString ();
		loadTrophyPrompt = "Get three stars on every level to unlock the trophy";
		cannot = "Level " + whichLevel.ToString () + " is locked";
		if (whichLevel>1 && !levelCan && whichLevel !=6)
		{
			Instantiate(padlock,new Vector3(transform.position.x,transform.position.y,transform.position.z-1) ,Quaternion.identity);
		}
		if (whichLevel == 6) {
			if ((PlayerPrefs.GetInt ("Stars for level 1") + PlayerPrefs.GetInt ("Stars for level 2") + PlayerPrefs.GetInt ("Stars for level 3") + PlayerPrefs.GetInt ("Stars for level 4") + PlayerPrefs.GetInt ("Stars for level 5") + PlayerPrefs.GetInt ("Stars for level 6")) < 15) {
				Instantiate (padlock, new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z - 1), Quaternion.identity);
			} else {
				trophyunlocked = true;
			}
		}
	}

	void Update(){
		if (inRange && whichLevel == 6 && trophyunlocked) {
			Instantiate (deathparticles, new Vector3 (transform.position.x, transform.position.y - 3, transform.position.z - 1), Quaternion.identity);
		}
	}

	void OnTriggerStay(Collider other){
		inRange = true;
		if (Input.touchCount > 0 && levelCan) {
			
			SceneManager.LoadScene (whichLevel);

			}

		if (Input.touchCount > 0 && whichLevel==1) {


			SceneManager.LoadScene (whichLevel);


		}
	}

	void OnTriggerExit(){
		inRange = false;
	}

	public Texture image;
	public string trophyWon;
	public GUISkin promptskin;
	private int defaultResolutionHeight;
	private int defaultFontSizebox;



	void OnGUI(){
		GUI.skin = promptskin;
		defaultResolutionHeight=320; // assume that you designed all your GUIs using 480p height...

		defaultFontSizebox=15;

		GUI.skin.box.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizebox; // ...then
		if (inRange) {
			if (levelCan && whichLevel == 1) {
				if (PlayerPrefs.GetInt ("Stars for level 1") == 1) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 1") == 2) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 1") == 3) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*7, Screen.height/5, Screen.width/8, Screen.height/5), image);
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadPrompt);
			}
			else if (levelCan && whichLevel == 2) {


				if (PlayerPrefs.GetInt ("Stars for level 2") == 1) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 2") == 2) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 2") == 3) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*7, Screen.height/5, Screen.width/8, Screen.height/5), image);
				}


					



				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadPrompt);
			}
			else if (levelCan && whichLevel == 3) {
				if (PlayerPrefs.GetInt ("Stars for level 3") == 1) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 3") == 2) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 3") == 3) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*7, Screen.height/5, Screen.width/8, Screen.height/5), image);
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadPrompt);
			}
			else if (levelCan && whichLevel == 4) {
				if (PlayerPrefs.GetInt ("Stars for level 4") == 1) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 4") == 2) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 4") == 3) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*7, Screen.height/5, Screen.width/8, Screen.height/5), image);
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadPrompt);
			}
			else if (levelCan && whichLevel == 5) {
				if (PlayerPrefs.GetInt ("Stars for level 5") == 1) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 5") == 2) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
				} else if (PlayerPrefs.GetInt ("Stars for level 5") == 3) {
					GUI.DrawTexture (new Rect ((Screen.width/11)*3, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*5, Screen.height/5, Screen.width/8, Screen.height/5), image);
					GUI.DrawTexture (new Rect ((Screen.width/11)*7, Screen.height/5, Screen.width/8, Screen.height/5), image);
				}
				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadPrompt);
			}

			else if (!levelCan && whichLevel == 6) {
				if ((PlayerPrefs.GetInt ("Stars for level 1") + PlayerPrefs.GetInt ("Stars for level 2") + PlayerPrefs.GetInt ("Stars for level 3") + PlayerPrefs.GetInt ("Stars for level 4") + PlayerPrefs.GetInt ("Stars for level 5") + PlayerPrefs.GetInt ("Stars for level 6")) < 15) {

					GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), loadTrophyPrompt);
				} else {
					GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), trophyWon);
				}
			}

			else
			{
				GUI.Box (new Rect (0, Screen.height - Screen.height / 8, Screen.width, Screen.height / 8), cannot);
			}
		}
	}
}
