using UnityEngine;
using System.Collections;

public class GhostGvocal : MonoBehaviour {
	public bool trig;
	public AudioSource source;
	public AudioClip[] clips;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (trig) {
			source.Stop();
			source.clip = clips[0];
			source.Play();
		} else if (!trig) {
			source.Stop();
			source.clip = clips[1];
			source.Play();
		}
	}
	void OnTriggerEnter(){
		trig = true;
	}
	void OnTriggerExit(){
		trig = false;
	}
}
