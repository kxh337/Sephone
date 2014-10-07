using UnityEngine;
using System.Collections;

public class LadderClimber : MonoBehaviour {
	private CharacterMotorMovement pMov;
	private CharacterMotor pMot;
	private FPSInputController pInput;
	private Collider ladder;
	
	public bool closeToLadder = false;
	public float climbSpeed = 3;
	public bool onLadder = false;
	public int incidentAngle = 20;
	
	// Use this for initialization
	void Start () {
		pMot = GetComponent<CharacterMotor> ();
		pInput = GetComponent<FPSInputController> ();
		pMov = pMot.movement;	
	}
	
	// Update is called once per frame
	void Update () {
 		if (closeToLadder) {
			if (!onLadder) {
				if (Input.GetAxis ("Vertical") > 0) {
					Vector3 camAngle = Camera.main.transform.forward;
					Vector3 colAngle = ladder.transform.forward;
					camAngle.y = colAngle.y = 0;
					float angle = Vector3.Angle (camAngle, colAngle);

					if (angle < incidentAngle) {
						climb ();
					}
				}
			} else {
				if (Input.GetAxis ("Vertical") > 0) {
					pMov.velocity.y = climbSpeed;
				} else if (Input.GetAxis ("Vertical") < 0) {
					pMov.velocity.y = -climbSpeed;
					if (pMot.grounded) {
						unclimb ();
					}
				} else if (Input.GetAxis ("Vertical") == 0) {
					pMov.velocity = Vector3.zero;
				}
			}
		} else {
			unclimb ();
		}
	}

	void climb() {
		pMot.grounded = false;
		pMov.gravity = 0;
		pInput.enabled = false;
		onLadder = true;
	}

	void unclimb() {
		pInput.enabled = true;
		pMov.gravity = 20;
		onLadder = false;
	}

	void OnTriggerEnter(Collider col) 
	{
		if (col.tag == "Ladder") {
			closeToLadder = true;
			ladder = col;
		}
	}
	
	void OnTriggerExit(Collider col) 
	{
		if (col.tag == "Ladder") {
			closeToLadder = false;
		}
	}
}
