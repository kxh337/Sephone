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
	public Texture2D creditPicture;
	public Texture2D helpPicture;
	Rect creditsRect;
	Rect helpRect;
	Rect newgameRect;
	Rect exitRect;
	int showMenus = 0;
	// Use this for initialization
	void Start () {

	}
	void OnGUI()  
	{
		if(showMenus == 0)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
		else if (showMenus == 1)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), creditPicture);
		else if (showMenus == 2)
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), helpPicture);
		Event e = Event.current;
		if(showMenus == 1 || showMenus == 2)
		{
			if(e.isMouse && e.type == EventType.mouseUp)
				showMenus = 0;
		}
		if(newgameRect.Contains(e.mousePosition) && showMenus == 0)
		{
			GUI.DrawTexture(newgameRect, newgame);
			if(e.isMouse && e.type == EventType.mouseUp)
				Application.LoadLevel(1);
		}
		else if(showMenus == 0)
		{
			GUI.DrawTexture(newgameRect, newgameRed);
		}

		if(helpRect.Contains(e.mousePosition) && showMenus == 0)
		{
			GUI.DrawTexture(helpRect, help);
			if(e.isMouse && e.type == EventType.mouseUp)
			{
				if(e.isMouse && e.type == EventType.mouseUp)
				{
					showMenus = 2;
				}
			}

		}
		else if(showMenus == 0)
		{
			GUI.DrawTexture(helpRect, helpRed);
		}

		if(creditsRect.Contains(e.mousePosition) && showMenus == 0)
		{
			GUI.DrawTexture(creditsRect, credits);
			if(e.isMouse && e.type == EventType.mouseUp)
			{
				showMenus = 1;
			}
			
		}
		else if(showMenus == 0)
		{
			GUI.DrawTexture(creditsRect, creditsRed);
		}

		if(exitRect.Contains(e.mousePosition) && showMenus == 0)
		{
			GUI.DrawTexture(exitRect, exit);
			if(e.isMouse && e.type == EventType.mouseUp)
			{
				Application.Quit();
			}
			
		}
		else if(showMenus == 0)
		{
			GUI.DrawTexture(exitRect, exitRed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		creditsRect = new Rect(0.8f * Screen.width, Screen.height * 0.6f, 0.12f * Screen.width, 0.12f * Screen.height);
		newgameRect = new Rect(0, Screen.height * 0.6f, 0.2f * Screen.width, 0.15f * Screen.height);
		helpRect = new Rect(0.1f * Screen.width, Screen.height * 0.8f, 0.1f * Screen.width, 0.15f * Screen.height);
		exitRect = new Rect(0.8f * Screen.width, Screen.height * 0.8f, 0.1f * Screen.width, 0.12f * Screen.height);

	}
}
