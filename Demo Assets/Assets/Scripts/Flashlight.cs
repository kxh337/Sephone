using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour {

	bool isLightOn = false;
	public AudioSource source;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Flashlight")) 
		{
			isLightOn = !isLightOn;
			audio.Play();
		}
		if(isLightOn) 
		{
			TurnLightOn();
		}
		else
			TurnLightOff();
	}

	void TurnLightOff() 
	{
		GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Light>().enabled = false;
	}

	void TurnLightOn()
	{
		GameObject.FindGameObjectWithTag("Flashlight").GetComponent<Light>().enabled = true;
	}
}
