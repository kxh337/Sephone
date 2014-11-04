using UnityEngine;
using System.Collections;

public class AmbientSounds : MonoBehaviour {
	public AudioClip[] clips;
	public AudioSource audioSource;
	public float nextLoadTime;
	private float startTime;
	private float endTime;
	private float nextClip;

	// Use this for initialization
	void Start () {
		//startTime = Time.time + 10f;
		audioSource.clip = clips[Random.Range(0,clips.Length-1)];
		audio.Play();
		//audioSource.volume = 0;
		//startLerp(audioSource);
		nextClip = Time.time + Random.Range(5,10);
	}
	
	// Update is called once per frame
	void Update () {
		//endTime = nextClip - 10f;
		if(Time.time > nextClip){
			Debug.Log("Changing audio");
			audioSource.clip = clips[Random.Range(0,clips.Length-1)];
			audio.Play();
			nextClip = Time.time  + Random.Range(5,10);
			startTime += nextClip;
		}
	}
		/*if (Time.time < startTime){
			Debug.Log("Start Lerp");
			startLerp(audioSource);
		}
		if (Time.time > endTime){
			Debug.Log("End Lerp");
			endLerp(audioSource);
		}
	}

	void endLerp(AudioSource source){
		source.volume = source.volume - .1f;
	}

	void startLerp(AudioSource source){
		source.volume = source.volume + .01f;
	}*/
}
