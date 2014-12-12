using UnityEngine;
using System.Collections;

public class TurnGhostJ : MonoBehaviour {
	private Vector3 vel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		vel = gameObject.rigidbody.velocity;

	}
}
