using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	private int buttonWidth = Screen.width / 6;
	private int buttonHeight = Screen.height / 11;
	private int groupWidth = Screen.width / 6;
	private int groupHeight = Screen.height / 2;
	private bool gamePaused = false; 
	public Texture2D quitText;
	public Texture2D loadText;
	public Texture2D optionsText;
	public Texture2D resumeText;
	public Texture2D saveText;
	public Texture2D pauseScreen;
	public Texture2D quitGlow;
	public Texture2D loadGlow;
	public Texture2D optionsGlow;
	public Texture2D resumeGlow;
	public Texture2D saveGlow;
	void Start() 
	{
		Screen.lockCursor = true;
	}

	// Update is called once per frame
	void Update () {
		int canPause = GameObject.Find("Totem").GetComponent<GamePause>().canPaused;
		if(Input.GetKeyUp(KeyCode.Escape) && (canPause == 0 || canPause == 1)) 
		{
			gamePaused = togglePause();
		}
	
	}

	void OnGUI() 
	{
		if(gamePaused) 
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseScreen); 
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2) + Screen.height / 9),
			                        groupWidth, groupHeight));
			Event ev = Event.current;

			Rect loadRect = new Rect(0, 0, buttonWidth / 2, buttonHeight * 0.9f);

			if(ev != null && loadRect.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(loadRect, loadGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do Load stuff here
				}

			}
			else 
				GUI.DrawTexture(loadRect, loadText);
			Rect resumeRect = new Rect(0, buttonHeight + Screen.height / 50, buttonWidth, buttonHeight);
			if(ev != null && resumeRect.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(resumeRect, resumeGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					gamePaused = false;
					togglePause();
				}
			}
			else
				GUI.DrawTexture(resumeRect, resumeText);

			Rect saveRect = new Rect(0, 2 * (buttonHeight + Screen.height / 50), buttonWidth / 2, buttonHeight * 0.9f);
			if(ev != null && saveRect.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(saveRect, saveGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do save stuff here
				}
			}
			else
				GUI.DrawTexture(saveRect, saveText);

			Rect optionsRect = new Rect(0, 3 * (buttonHeight + Screen.height / 50), buttonWidth, buttonHeight);
			if(ev != null && optionsRect.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(optionsRect, optionsGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do options stuff here
				}
			}
			else
				GUI.DrawTexture(optionsRect, optionsText);

			Rect quitRect = new Rect(0, 4 * (buttonHeight + Screen.height / 50), buttonWidth / 2, buttonHeight * 0.9f);
			if(ev != null && quitRect.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(quitRect, quitGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do save stuff here
				}
			}
			else
				GUI.DrawTexture(quitRect, quitText);
			GUI.EndGroup();
		}
	}

	bool togglePause() 
	{
		if(Time.timeScale == 0)
		{
			GameObject.Find("Totem").GetComponent<GamePause>().canPaused = 0;
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = true;
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return false;
		}
		else
		{
			GameObject.Find("Totem").GetComponent<GamePause>().canPaused = 1;
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = false;
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}



}
