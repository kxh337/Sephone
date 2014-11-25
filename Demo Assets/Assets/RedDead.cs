using UnityEngine;
using System.Collections;

public class RedDead : MonoBehaviour {
	public bool danger1;
	public bool danger2;
	public bool danger3;
	public Texture2D red1;
	public Texture2D red2;
	public Texture2D red3;
	public AudioSource source;
	public AudioClip beat;
	public AudioClip fasterbeat;
	private Rect rect;
	private Color tempRed1;
	private Color tempRed2;
	private Color tempRed3;
	private bool played1;
	private bool played2;
	private bool played3;
	private int totem;
	private float alpha;
	// Use this for initialization
	void Start () {
		rect = new Rect(0,0, Screen.width, Screen.height);
		source.loop = true;
		played1 = false;
		played2 = false;
		played3 = false;
		source.Stop();
		alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		totem = GameObject.Find("Totem").GetComponent<GamePause>().canPaused;
		if(!danger1 && !danger2 && !danger3){
			played1 = false;
			played2 = false;
			played3 = false;
			source.Stop();
		}
		if(danger1){
			if(!played1){
				source.Stop();
				source.clip = beat;
				source.Play();
				played1 = true;
			}
		}
		else{
			played1 = false;
		}
		if(danger2){
			if(!played2){
				source.Stop();
				source.clip = fasterbeat;
				source.Play();
				played2 = true;
			}
		}
		else{
			played2 = false;
		}
		if(danger3){
			if(!played3){
				source.Stop();
				source.clip = fasterbeat;
				source.Play();
				played3 = true;
			}
		}
		else{
			played3 = false;

		}
	
	}

	void OnGUI(){

		if(totem == 0 || totem ==2){
			if(danger1){
//				blinkTexture(red1,tempRed1,.5f,);
				Debug.Log("Danger 1");

			}
			else if(danger2){
//				blinkTexture(red2,tempRed2,.7f);
				Debug.Log("Danger 2");
			}
			else if(danger3){
//				blinkTexture(red3, tempRed3,1f);
				Debug.Log("Danger 3");
			}
			else{
				//Debug.Log("Safe");

			}
		}
	}

	void blinkTexture(Texture2D texture, Color tempColor, float alpha, float minAlpha, float maxAlpha){
		if(alpha >= maxAlpha){
			alpha = minAlpha;
		}
		GUI.color = new Color(1f,1f,1f,alpha + .25f);
		GUI.DrawTexture(rect,texture);
	}
	
}
