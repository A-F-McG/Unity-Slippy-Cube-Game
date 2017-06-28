using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {



	public int currentLevel;

	private bool showScreen = false;
	private bool dead = false;



	void Start()
	{
		if (PlayerPrefs.GetInt ("Level Completed") > 0) {
			currentLevel = PlayerPrefs.GetInt ("Level Completed");
		} else {
			currentLevel = 0;
		}
	}


	public void completeLevel(){
		if (SceneManager.GetActiveScene ().buildIndex > currentLevel) {
			currentLevel += 1;
		}
		Save ();
		Time.timeScale = 0f;
		showScreen = true;

	}
	public void diedLevel(){
		currentLevel+=1;
		Time.timeScale = 0f;
		dead = true;
	}
	public void LoadNextLevel()
	{
		Save ();
		Time.timeScale = 1f;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Save (){
		PlayerPrefs.SetInt ("Level Completed", currentLevel);
		PlayerPrefs.GetInt ("Level Completed");
	}


	private int thisLevel;
	private bool oneStar=false;
	public Texture workplease;

	public void oneLife() {
		oneStar = true;
	}

	public GUISkin managerskin;

	private int defaultResolutionHeight;
	private int defaultFontSizebox;
	private int defaultFontSizebutton;

		

	void OnGUI(){
		GUI.skin = managerskin;
		defaultResolutionHeight=320; // assume that you designed all your GUIs using 480p height...
		defaultFontSizebutton= 15; // ...and used 24 points on the font size
		defaultFontSizebox=13;
		GUI.skin.button.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizebutton; // ...then
		GUI.skin.box.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizebox; // ...then
		Rect screenMenu = new Rect (Screen.width / 4, Screen.height / 6, Screen.width / 2, Screen.height / 2);
		if (showScreen) {
					
			if (SceneManager.GetActiveScene().buildIndex != 5) {
				GUI.Box (screenMenu, "");
			}
				else{
				GUI.Box (screenMenu, "Well done !! You've completed\n all the levels. Amazeballs.");
				}

			if (SceneManager.GetActiveScene ().buildIndex != 5) {
				if (GUI.Button (new Rect (screenMenu.x + Screen.width / 5 + 20, screenMenu.y + Screen.height / 4, Screen.width / 5, Screen.width / 10), "Next Level")) {
					LoadNextLevel ();
				}
			}
				if (GUI.Button (new Rect (screenMenu.x + 20, screenMenu.y + Screen.height / 4, Screen.width / 5, Screen.width / 10), "Main Menu")) {
					Time.timeScale = 1f;
					SceneManager.LoadScene (0);
				}
				if (GUI.Button (new Rect (screenMenu.x + Screen.width / 5 + 20, screenMenu.y + Screen.height / 4 - Screen.width / 10, Screen.width / 5, Screen.width / 10), "Try Again")) {
					Time.timeScale = 1f;
					SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
					;
				}


		}
		if (dead) {

			GUI.Box (screenMenu, "All lives lost");
			if (GUI.Button (new Rect (screenMenu.x + Screen.width / 5+20, screenMenu.y + Screen.height / 4, Screen.width/5, Screen.width/10), "Try Again")) {
				Time.timeScale = 1f;
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
			if (GUI.Button (new Rect (screenMenu.x+20, screenMenu.y + Screen.height / 4, Screen.width/5, Screen.width/10), "Main Menu")) {
				Time.timeScale = 1f;
				SceneManager.LoadScene (0);
			}
		

}
}
}
