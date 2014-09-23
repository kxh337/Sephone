#pragma strict

private var CameraScript : CameraSwitch;
var radius = 5.0;
var power = 10.0;

function Explode() 
{
	CameraScript = GameObject.Find("Main Camera").GetComponent(CameraSwitch);
	var explosionPos: Vector3 = transform.position;
	var colliders:Collider[] = Physics.OverlapSphere(explosionPos, radius);
	
		for (var hit : Collider in colliders) {
			if(!hit) {
				continue;
			}
			if (hit.rigidbody) 
				hit.rigidbody.AddExplosionForce(power, explosionPos, radius, 3.0);
				GoBack();
			
		}
		
}		

function GoBack() 
{
	yield WaitForSeconds(3);
	CameraScript.mainCameraSwitch();
}	