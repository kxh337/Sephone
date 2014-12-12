using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	private float buttonSize = (float) Screen.width / 1500;
	private int groupWidth = Screen.width / 4;
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
	public Texture2D helpMenu;
	private bool showHelp = false;
	Rect[] rects;

	void Start() 
	{
		Screen.lockCursor = true;
		space = groupHeight / 4;
		rects = new Rect[5];
		rects[0] = new Rect((groupWidth - buttonSize * resumeText.width) / 2, 1 * space, buttonSize * resumeText.width, buttonSize * resumeText.height);
		rects[1] = new Rect((groupWidth - buttonSize * optionsText.width) / 2, 2 * space, buttonSize * optionsText.width, buttonSize * optionsText.height);
		rects[2] = new Rect((groupWidth - buttonSize * quitText.width) / 2, 3 * space, buttonSize * quitText.width, buttonSize * optionsText.height);
		
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
		Event ev = Event.current;
		if(gamePaused) 
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseScreen); 
			GUI.BeginGroup(new Rect((Screen.width - groupWidth) / 2, (Screen.height - groupHeight) / 2 + Screen.height / 9,
			                        groupWidth, groupHeight));


			if(ev != null && rects[0].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[0], resumeGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					gamePaused = false;
					togglePause();
				}
			}
			else
				GUI.DrawTexture(rects[0], resumeText);

			if(ev != null && rects[1].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[1], optionsGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					showHelp = true;
				}
			}
			else
				GUI.DrawTexture(rects[1], optionsText);

			if(ev != null && rects[2].Contains(ev.mousePosition))
			{
				GUI.DrawTexture(rects[2], quitGlow);
				if(ev.isMouse && ev.type == EventType.mouseUp)
				{
					Application.Quit();
				}
			}
			else
				GUI.DrawTexture(rects[2], quitText);
			GUI.EndGroup();
		}
		if(showHelp)
		{
			Event e = Event.current;
			GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), helpMenu);
			if(e.isMouse && e.type == EventType.mouseDown)
			{
				showHelp = false;
			}
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
