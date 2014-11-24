using UnityEngine;
using System.Collections;

public class ForceTurn : MonoBehaviour {
	public AudioClip audio;
	public AudioSource audioSource;
	private float turnTime;
	public float angle;
	public Transform player;
	public float step;
	public float wait;
	private MouseLook mouse;
	private CharacterMotor motor;
	private bool triggered;
	private CharacterController charControl;
	private float triggerTime;
	private bool turned;
	// Use this for initialization
	void Start () {
		audioSource.clip = audio;
		mouse = player.GetComponent<MouseLook>();
		motor = player.GetComponent<CharacterMotor>();
		triggered = false;
		charControl = player.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered && !turned){
			Vector3 newDir = Vector3.RotateTowards(player.transform.forward, transform.forward, step, 0.0F);
			player.transform.rotation = Quaternion.LookRotation(newDir);
			Debug.Log("turning");
			mouse.enabled = false;
			motor.enabled = false;
		}
		if(Time.time > turnTime && Time.time < triggerTime){
			turned = true;
			Debug.Log("moving");
			charControl.SimpleMove(gameObject.transform.forward*Time.deltaTime);
			mouse.enabled = false;
			motor.enabled = false;
		}
		if(Time.time > triggerTime){
			//mouse.enabled = true;
			motor.enabled = true;
			turned = false;
		}

	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			triggered = true;
			turnPlayer(other.gameObject);
			turnTime = Time.time + wait;
			triggerTime = Time.time + wait*2f;
			mouse.enabled = false;
			motor.enabled = false;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			triggered = false;

		}
	}

	void turnPlayer(GameObject player){
		mouse.enabled = false;
		motor.enabled = false;
	}
}
