#pragma strict

var startingShakeDistance : float = 0.8;
var decreasePercentage : float = 0.5;
var shakeSpeed : float = 50;
var numShakes : int = 10;
var cam : Camera;

function CameraShake() 
{
	var hitTime : float = Time.time;
	var originalPositionX : float = cam.transform.localPosition.x;
	var originalPositionY : float = cam.transform.localPosition.y;
	var shake = numShakes;
	var shakeDistance : float = startingShakeDistance;
	
	while (shake != 0) 
	{
		var timer : float = (Time.time - hitTime) * shakeSpeed;
		//.transform.localPosition.x = originalPositionX + Mathf.Sin(timer) * shakeDistance;
		cam.transform.localPosition.y = originalPositionY + Mathf.Cos(timer) * shakeDistance;
		if (timer > Mathf.PI * 2) 
		{
			hitTime = Time.time;
			shakeDistance *= decreasePercentage;
			shake--;
		}
		yield;
	}
	cam.transform.localPosition.y = originalPositionY;
	cam.transform.localPosition.x = originalPositionX;
}