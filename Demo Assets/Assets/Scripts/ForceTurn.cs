using UnityEngine;
using System.Collections;

public class ForceTurn : MonoBehaviour {
	public RoomTrigger room;
	public AudioClip audio;
	public AudioSource audioSource;
	public float turnDuration;
	private float turnTime;
	public float angle;
	public Transform player;
	private MouseLook mouse;
	private CharacterMotor motor;
	// Use this for initialization
	void Start () {
		audioSource.clip = audio;
		mouse = player.GetComponent<MouseLook>();
		motor = player.GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time < turnTime){
			mouse.enabled = true;
			motor.enabled = true;
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && !room.roomExited){
			turnPlayer(other.gameObject);
		}
	}

	void turnPlayer(GameObject player){
		mouse.enabled = false;
		motor.enabled = false;
		turnTime = Time.time + turnDuration;
		player.transform.RotateAround(Vector3.zero, Vector3.up,angle*Time.deltaTime);
	}
}
