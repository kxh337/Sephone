using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 320;
	private bool gamePaused = false; 
	public Texture2D inventoryText;
	public Texture2D quitText;
	public Texture2D loadText;
	public Texture2D optionsText;
	public Texture2D resumeText;
	public Texture2D saveText;
	public Texture2D pauseScreen;

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
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2) + 60),
			                        groupWidth, groupHeight));
			GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), loadText);
			/*if(GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), loadText))
			{

			}*/
			if(GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), resumeText))
			{
				gamePaused = false;
				togglePause();
			}
			if(GUI.Button(new Rect(0, 120, buttonWidth, buttonHeight), saveText))
			{
				Application.Quit();
			}
			if(GUI.Button(new Rect(0, 180, buttonWidth, buttonHeight), optionsText))
			{

			}
			if(GUI.Button(new Rect(0, 240, buttonWidth, buttonHeight), quitText))
			{
				
			}
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
