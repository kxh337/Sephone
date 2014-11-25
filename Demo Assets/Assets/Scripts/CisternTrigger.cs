using UnityEngine;
using System.Collections;

public class CisternTrigger : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	private bool played;
	
	// Use this for initialization
	void Start () {
		played = false;

	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && !played){
			audio.Play();
			GameObject.FindGameObjectWithTag("CisternCamera").GetComponent("CameraSwitch").SendMessage("turnCutSceneOn");
			played = true;
		}
	}
}
