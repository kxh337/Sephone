using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	public float triggerdist;
	public Transform player;
	private bool played;

	// Use this for initialization
	void Start () {
		source.clip = sound;
		played = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, player.position) < triggerdist && !played){
			audio.Play();
			played = true;
		}
		/*else if(Vector3.Distance(transform.position, player.position) > triggerdist){
			played = false;
		}*/
	}
}
