using UnityEngine;
using System.Collections;

public class PlayerForce : MonoBehaviour {

	public int pushPower = 250;
	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		//body.velocity = pushDir * pushPower;
		body.AddForce(pushDir * pushPower);
	}
}
