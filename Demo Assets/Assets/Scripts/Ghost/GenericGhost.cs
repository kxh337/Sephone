using UnityEngine;
using System.Collections;

public class GenericGhost : MonoBehaviour {
	public Transform player;
	public bool triggered;
	public float warningZone;
	public float warningZone1;
	public float killZone;
	public RedDead death;
	private float playerDist;
	Vector3 lastPosition = Vector3.zero;
	public float rotateSpeed = 250;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		baseUpdate();
	}

	protected void baseUpdate() {	
		checkDeathDist();
		faceForward ();
	}

	void faceForward() {
//		transform.LookAt (transform.position + (transform.position - lastPosition));
		Vector3 speed = transform.position - lastPosition;
		if (speed != Vector3.zero)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(speed.x,0,speed.z)), Time.deltaTime * rotateSpeed);
		}

		lastPosition = transform.position;
	}

	void checkDeathDist(){
		playerDist = Vector3.Distance(player.transform.position,gameObject.transform.position);

		//Debug.Log(playerDist);

		if(playerDist < killZone){
			//kill player and respawn at last checkpoint
			death.danger3 = true;
			death.danger2 = false;
			death.danger1 = false;
		}
		else if(playerDist < warningZone1){
			//more warning on screen with hard hearbeating
			death.danger3 = false;
			death.danger2 = true;
			death.danger1 = false;
		}
		else if(playerDist < warningZone){
			//light warning and lighter heartbeating
			death.danger3 = false;
			death.danger2 = false;
			death.danger1 = true;
		}
		else{
			death.danger3 = false;
			death.danger2 = false;
			death.danger1 = false;
		}
	}
}
