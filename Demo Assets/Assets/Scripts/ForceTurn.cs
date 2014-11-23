using UnityEngine;
using System.Collections;

public class ForceTurn : MonoBehaviour {
	public RoomTrigger room;
	public AudioClip audio;
	public AudioSource audioSource;
	public float turnDuration;
	private float turnTime;
	// Use this for initialization
	void Start () {
		audioSource.clip = audio;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time < turnTime)
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && !room.roomExited){
			turnPlayer(other.gameObject);
		}
	}

	void turnPlayer(GameObject player){
		MouseLook mouse = player.GetComponent<MouseLook>();
		CharacterMotor motor = player.GetComponent<CharacterMotor>();
		mouse.enabled = false;
		motor.enabled = false;
		turnTime = Time.time + turnDuration;
		player.
	}
}
