using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class myGUI : MonoBehaviour {

	public GUISkin skin;

	private int defaultResolutionHeight;
	private int defaultFontSizelabel;
	private int defaultFontSizebutton;

	void OnGUI ()
	{
		
		GUI.skin = skin;
		defaultResolutionHeight=320; // assume that you designed all your GUIs using 480p height...
		defaultFontSizebutton= 20; // ...and used 24 points on the font size
		defaultFontSizelabel=35;
		GUI.skin.button.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizebutton; // ...then
		GUI.skin.label.fontSize = (Screen.height / defaultResolutionHeight)  * defaultFontSizelabel; // ...then
		GUI.Label (new Rect (Screen.width/4, Screen.height/6, Screen.width, Screen.height/3), "Slippery Cube");
		//if (PlayerPrefs.GetInt ("Level Completed") > 0) {
			//if (GUI.Button (new Rect (200, 90, 100, 70), "Play")) {
				//SceneManager.LoadScene (PlayerPrefs.GetInt ("Level Completed")+1);
			//}
		//}

		if (PlayerPrefs.GetInt ("Level Completed") > 0) {
			if (GUI.Button (new Rect ((Screen.width/3)*2, Screen.height/3, Screen.width/3, Screen.height/2), "Continue\nGame")) {
				SceneManager.LoadScene ("Level World");
			}
		}
		if (GUI.Button (new Rect (0, Screen.height/3, Screen.width/3, Screen.height/2), " New \nGame")) 
		{
			PlayerPrefs.SetInt ("Level Completed", 0);
			PlayerPrefs.SetInt ("Stars for level 1", 0);
			PlayerPrefs.SetInt ("Stars for level 2", 0);
			PlayerPrefs.SetInt ("Stars for level 3", 0);
			PlayerPrefs.SetInt ("Stars for level 4", 0);
			PlayerPrefs.SetInt ("Stars for level 5", 0);
			PlayerPrefs.SetInt ("Stars for level 6", 0);
			PlayerPrefs.SetInt ("Stars for level 7", 0);
			PlayerPrefs.SetInt ("Stars for level 8", 0);
			PlayerPrefs.SetInt ("Stars for level 9", 0);
			PlayerPrefs.SetInt ("Stars for level 10", 0);

			SceneManager.LoadScene ("Level World");
		}
		if (GUI.Button (new Rect (Screen.width/3, Screen.height/3, Screen.width/3, Screen.height/2), "Quit")) 
		{
			Application.Quit ();
		}
	}
}
