using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {


	private int buttonWidth = 200;
	private int buttonHeight = 50;
	private int groupWidth = 200;
	private int groupHeight = 170;
	private bool gamePaused = false; 

	void Start() 
	{
		Screen.lockCursor = true;
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)) 
		{
			gamePaused = togglePause();
		}
		if(!gamePaused) 
		{
			Screen.lockCursor = true;
		}
	
	}

	void OnGUI() 
	{
		if(gamePaused) 
		{
			GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)),
			                        groupWidth, groupHeight));
			if(GUI.Button(new Rect(0, 0, buttonWidth, buttonHeight), "Resume"))
			{
				gamePaused = false;
				togglePause();
			}
			if(GUI.Button(new Rect(0, 60, buttonWidth, buttonHeight), "Restart"))
			{
				togglePause();
				Application.LoadLevel(0);
			}
			if(GUI.Button(new Rect(0, 120, buttonWidth, buttonHeight), "Quit"))
			{
				Application.Quit();
			}
			GUI.EndGroup();
		}
	}

	bool togglePause() 
	{
		if(Time.timeScale == 0)
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = true;
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return false;
		}
		else
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = false;
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}



}
