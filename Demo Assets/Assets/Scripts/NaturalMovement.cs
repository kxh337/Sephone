using UnityEngine;
using System.Collections;

public class NaturalMovement : MonoBehaviour {
	public GameObject reference;
	public GameObject player;
	public float verticalPercentage = 30;
	public float horizontalPercentage = 30;

	// Use this for initialization
	void Start () {
	}
	
//	// Update is called once per frame
//	void Update () {
//		float newx = reference.transform.rotation.x * verticalPercentage / 100;
//		float newz = player.rigidbody.angularVelocity.y * horizontalPercentage / 100;
////		Debug.Log(newx);
//		Debug.Log(reference.transform.rotation.x + " " + newx);
//		transform.localRotation = new Quaternion (	newx,
//		                                		    transform.rotation.y,
//				                                    newz,
//				                                    transform.rotation.w);
//		                                    
//	}
}
