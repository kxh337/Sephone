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

	void Start () {
		pMot = GetComponent<CharacterMotor> ();
		pInput = GetComponent<FPSInputController> ();
		pMov = pMot.movement;	
	}

	void Update () {
 		if (closeToLadder) {
			if (!onLadder) {
				// If not on ladder, climb only when walk towards its front
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
				// If on lader, move up or down based on input
				if (Input.GetAxis ("Vertical") > 0) {
					pMov.velocity.y = climbSpeed;
				} else if (Input.GetAxis ("Vertical") < 0) {
					pMov.velocity.y = -climbSpeed;
					// Moving backwards unclimb if on ground
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
