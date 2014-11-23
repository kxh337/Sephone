using UnityEngine;
using System.Collections;

public class RedDead : MonoBehaviour {
	public GUITexture red1;
	public GUITexture red2;
	public GUITexture red3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void danger1(){
		Debug.Log("Danger Level: 1");
	}

	public void danger2(){
		Debug.Log("Danger Level: 2");
	}

	public void danger3(){
		Debug.Log("Danger Level: 3");
	}
}
