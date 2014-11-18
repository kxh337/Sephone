using UnityEngine;
using System.Collections;

public class AstarTrigger : MonoBehaviour {
	public GhostG ghost;
	public bool entered;
	public bool exited;
	// Use this for initialization
	void Start () {
		exited = false;
		entered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(entered){
			ghost.triggered = true;
		}
		else{
			ghost.triggered =false;
		}
	}
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			entered = true;
			exited = false;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			entered = false;
			exited = true;
		}
	}
}
