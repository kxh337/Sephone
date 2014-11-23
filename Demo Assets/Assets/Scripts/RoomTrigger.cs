using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {
	public bool roomEntered;
	public bool roomExited;
	// Use this for initialization
	void Start () {
		roomEntered = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			roomEntered = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			roomExited = true;
		}
	}
}
