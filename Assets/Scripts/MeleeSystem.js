#pragma strict

var TheDamage:int = 50;
var Distance:float;
var MaxDistance:float = 1.5;
//var TheMace:Transform;
var TheSystem:Transform;
function Update() {
	if (Input.GetButtonDown("Fire1")) 
	{
		//Attack animation
		animation.Play("attack");
		AttackDamage();
	}
	if (animation.isPlaying == false) {
		animation.CrossFade("idle");
	}
	
	if (Input.GetKey(KeyCode.LeftShift)) {
		animation.CrossFade("sprint");	
	}
	if (Input.GetKeyUp(KeyCode.LeftShift)) {
		animation.CrossFade("idle");
	}
}

function AttackDamage() {
	var hit:RaycastHit;
		if (Physics.Raycast(TheSystem.transform.position, TheSystem.transform.TransformDirection(Vector3.forward), hit))
		{
			Distance = hit.distance;
			if (Distance < MaxDistance) {
				hit.transform.SendMessage("ApplyDamage", TheDamage, SendMessageOptions.DontRequireReceiver);
			}
		}
}
		