using UnityEngine;
using System.Collections;

public class GenericGhost : MonoBehaviour {
	public Transform player;
	public bool triggered;

	public RedDead death;
	Vector3 lastPosition = Vector3.zero;
	public float rotateSpeed = 250;
	public float playerDist;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}


	protected void baseUpdate(float dist) {	
		faceForward ();
	}

	void faceForward() {
		Vector3 speed = transform.position - lastPosition;
		if (speed != Vector3.zero)
		{
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(speed.x,0,speed.z)), Time.deltaTime * rotateSpeed);
		}

		lastPosition = transform.position;
	}


}
