using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
	public bool activated;
	public int value;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag =="Player"){
			activated =true;
		}
	}
}
