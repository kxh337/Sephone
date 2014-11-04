using UnityEngine;
using System.Collections;

public class CompanionSpirit : MonoBehaviour {
	public Transform player;
	public float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,player.position.y + offset,transform.position.z);
	}
}
