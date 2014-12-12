using UnityEngine;
using System.Collections;

public class GhostJTurn : MonoBehaviour {
	public float speed;
	public GhostJ jghost;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		faceForward ();
	}
	void faceForward() {
		Vector3 targetDir = jghost.nextPoint.position - transform.position;
		float step = speed * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);

	}
}
