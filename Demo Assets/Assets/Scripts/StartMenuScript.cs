using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {
	public Texture2D credits;
	public Texture2D creditsRed;
	public Texture2D help;
	public Texture2D helpRed;
	public Texture2D exit;
	public Texture2D exitRed;
	public Texture2D newgame;
	public Texture2D newgameRed;
	public Texture2D background;
	Rect creditsRect;
	Rect helpRect;
	// Use this for initialization
	void Start () {

	}
	void OnGUI()  
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		//GUI.DrawTexture(new Rect(0, Screen.height * 0.8f, background.width, background.height), background);
	}
	
	// Update is called once per frame
	void Update () {
		Rect creditsRect = new Rect(Screen.width - credits.width, Screen.height * 0.8f, credits.width, credits.height);
		Rect helpRect = new Rect(Screen.width - help.width, Screen.height * 0.8f + creditsRect.height, help.width, help.height);
	}
}
