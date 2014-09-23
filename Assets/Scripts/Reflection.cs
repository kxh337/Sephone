using UnityEngine;
using System.Collections;

public class Reflection : MonoBehaviour {
	public Transform originalObject;
	public Transform reflectedObject;
	// Use this for initialization
	void Start () {
		Debug.Log("start position" + reflectedObject.position);
	
	}
	
	// Update is called once per frame
	void Update () {
		reflectedObject.forward = Vector3.Reflect(originalObject.forward, Vector3.up);
		Debug.Log(reflectedObject.position);
	}
}
