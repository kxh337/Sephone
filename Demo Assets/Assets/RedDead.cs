using UnityEngine;
using System.Collections;

public class RedDead : MonoBehaviour {
	public bool danger1;
	public bool danger2;
	public bool danger3;
	public GUITexture red1;
	public GUITexture red2;
	public GUITexture red3;
	public AudioSource source;
	public AudioClip beat;
	public AudioClip fasterbeat;
	private Rect rect;
	private Color tempRed1;
	private Color tempRed2;
	private Color tempRed3;
	// Use this for initialization
	void Start () {
		rect = new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);
		source.loop = true;
		red1.pixelInset = rect;
		red2.pixelInset = rect;
		red3.pixelInset = rect;
		tempRed1 = red1.color;
		tempRed2 = red2.color;
		tempRed3 = red3.color;

	}
	
	// Update is called once per frame
	void Update () {
		if(danger1 || danger2){
			source.clip = beat;
			source.Play();
		}
		if(danger3){
			source.clip = fasterbeat;
			source.Play();
		}

	
	}

	void OnGUI(){
		if(danger1){
			blinkTexture(red1,tempRed1);
			Debug.Log("Danger 1");
		}
		else if(danger2){
			blinkTexture(red2,tempRed2);
			Debug.Log("Danger 2");
		}
		else if(danger3){
			blinkTexture(red3, tempRed3);
			Debug.Log("Danger 3");
		}
		else{
			Debug.Log("Safe");
			tempRed1.a = 0f;
			tempRed2.a = 0f;
			tempRed3.a = 0f;
			red1.color = tempRed1;
			red2.color = tempRed2;
			red3.color = tempRed3;

		}
	}

	void blinkTexture(GUITexture texture, Color tempColor){
		tempColor.a = .5f;
		texture.color = tempColor;
	}
	
}
