using UnityEngine;
using System.Collections;

public class GhostTrigger : MonoBehaviour {
	public GenericGhost ghost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			ghost.triggered = true;
		}
	}
}
