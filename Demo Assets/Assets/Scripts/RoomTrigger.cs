using UnityEngine;
using System.Collections;

public class RoomTrigger : MonoBehaviour {
	public bool roomEntered;
	public bool roomExited;
	public GameObject turnobject;
	private ForceTurn turn;
	// Use this for initialization
	void Start () {
		roomEntered = false;
		turnobject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			roomEntered = true;
			turnobject.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Player"){
			roomExited = true;
		}
	}
}
