using UnityEngine;
using System.Collections;

public class AITarget : MonoBehaviour {
	public Transform aiMap;
	public float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,aiMap.position.y + offset,transform.position.z);
	}
}
