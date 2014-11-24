using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private float buttonSize = (float) Screen.width / 1500;
	private int groupWidth = Screen.width / 5;
	private int groupHeight = Screen.height / 2;
	private int space;
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
	Rect[] rects;

	void Start() 
	{
		Screen.lockCursor = true;
		space = groupHeight / 5;
		rects = new Rect[5];
		Debug.Log (buttonSize * loadText.height);
		Debug.Log (loadText.height);
		Debug.Log (buttonSize * quitText.height);
		Debug.Log (quitText.height);
		rects[0] = new Rect((groupWidth - loadText.width) / 2, 0 * space, buttonSize * loadText.width, buttonSize * loadText.height);
		rects[1] = new Rect((groupWidth - resumeText.width) / 2, 1 * space, buttonSize * resumeText.width, buttonSize * resumeText.height);
		rects[2] = new Rect((groupWidth - saveText.width) / 2, 2 * space, buttonSize * saveText.width, buttonSize * saveText.height);
		rects[3] = new Rect((groupWidth - optionsText.width) / 2, 3 * space, buttonSize * optionsText.width, buttonSize * optionsText.height);
		rects[4] = new Rect((groupWidth - quitText.width) / 2, 4 * space, buttonSize * quitText.width, buttonSize * optionsText.height);
		
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
			GUI.BeginGroup(new Rect((Screen.width - groupWidth) / 2, (Screen.height - groupHeight) / 2 + Screen.height / 9,
			                        groupWidth, groupHeight));
			Event ev = Event.current;

			if(ev != null && rects[0].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[0], loadGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do Load stuff here
				}
			}
			else 
				GUI.DrawTexture(rects[0], loadText);

			if(ev != null && rects[1].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[1], resumeGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					gamePaused = false;
					togglePause();
				}
			}
			else
				GUI.DrawTexture(rects[1], resumeText);

			if(ev != null && rects[2].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[2], saveGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do save stuff here
				}
			}
			else
				GUI.DrawTexture(rects[2], saveText);

			if(ev != null && rects[3].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[3], optionsGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do options stuff here
				}
			}
			else
				GUI.DrawTexture(rects[3], optionsText);

			if(ev != null && rects[4].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[4], quitGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					//Do save stuff here
				}
			}
			else
				GUI.DrawTexture(rects[4], quitText);
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
