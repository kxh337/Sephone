using UnityEngine;
using System.Collections;

public class TurnGhostJ : GenericGhost {
	private Vector3 vel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(player.transform.position,gameObject.transform.position);
		vel = gameObject.rigidbody.velocity;

	}
}
