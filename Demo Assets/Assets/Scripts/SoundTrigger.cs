using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	public Transform player;
	private bool played;

	// Use this for initialization
	void Start () {
		source.clip = sound;
		played = false;
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && !played){
			audio.Play();
			played = true;
		}
	}

}
