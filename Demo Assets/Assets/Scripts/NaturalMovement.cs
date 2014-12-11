using UnityEngine;
using System.Collections;

public class NaturalMovement : MonoBehaviour {
	public float verticalPercentage = 35;
	public float horizontalPercentage = 20;
	private float previousAngleY = 0;
	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		float speedAngleY = parent.eulerAngles.y - previousAngleY;
		float newy = Mathf.LerpAngle(transform.localEulerAngles.y, speedAngleY, Time.deltaTime * horizontalPercentage);
		float adjustedAngleX = ((parent.eulerAngles.x + 90) % 360) - 90;
		float newx = adjustedAngleX * verticalPercentage / 100;
		transform.localEulerAngles = new Vector3 (newx, newy, transform.localEulerAngles.z);

		previousAngleY = parent.eulerAngles.y;
	}
}
