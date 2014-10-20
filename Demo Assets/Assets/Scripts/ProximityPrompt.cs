using UnityEngine;
using System.Collections;

public class ProximityPrompt : MonoBehaviour {

	bool isAction = false;
	public string actionDescription;


	void OnGUI()
	{
		if(isAction)
		{
			int textWidth = 250;
			int textHeight = 50;
			GUI.Label(new Rect((Screen.width / 2) - (textWidth / 2), (Screen.height / 1.2f) - (textHeight / 2), textWidth, 
			                   textHeight), actionDescription);
		}
	}
	
	void OnTriggerEnter(Collider col) 
	{
		if(col.tag == "Player")
		{
			isAction = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			isAction = false;
		}
	}
}
