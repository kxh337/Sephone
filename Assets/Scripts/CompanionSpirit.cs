using UnityEngine;
using System.Collections;

public class CompanionSpirit : MonoBehaviour {
	public Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,player.position.y,transform.position.z);
	}
}
