#pragma strict

private var cameraShake : CameraShake;

function Start() 
{
	cameraShake = GameObject.Find("Main Camera").GetComponent(CameraShake);	
}

function OnTriggerEnter (Col : Collider) 
{
	if (Col.tag == "Player") 
	{
		cameraShake.CameraShake();
	}
}