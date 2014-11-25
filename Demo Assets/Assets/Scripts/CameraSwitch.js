#pragma strict

var camera1 : Camera;
var camera2 : Camera;
var animationDuration : float;
var blackTexture : Texture2D;
var cutScenePlaying : boolean;
var alphaValue : float;
var animationNumber : int;
//private var boxPhysics : BoxPhysics;

function Start() {
	/*GameObject.Find("Player").GetComponent(FPSInputController).enabled = false;
	GameObject.Find("Flashlight").GetComponent(Light).enabled = false;
	GameObject.Find("Graphics").GetComponent(MeshRenderer).enabled = false;
	camera1.camera.enabled = false;
	camera2.camera.enabled = true;
	camera2.animation.Play();
	
	yield WaitForSeconds(animationDuration);
	if(camera2.animation.isPlaying == false)
	{
		mainCameraSwitch();
	}
	
	/*boxPhysics = GameObject.Find("ExplosionOrigin").GetComponent(BoxPhysics);
	
	yield WaitForSeconds(2);
	moveBoxes();*/
	
	//If the animation is the first animation in the game, play it
	if(animationNumber == 0)
	{
		turnCutSceneOn();
	}
	alphaValue = 0.0f;
}	

function Update() 
{
	if(cutScenePlaying)
	{
		alphaValue += Mathf.Clamp01(Time.deltaTime / 4); 
	}
}

function OnGUI()
{
	if(cutScenePlaying) 
	{
		GUI.color = new Color(1.0f, 1.0f, 1.0f, alphaValue);
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
		GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
	
}

function turnCutSceneOn()
{
	//GameObject.Find("Player").GetComponent(FPSInputController).enabled = false;
	GameObject.Find("Flashlight").GetComponent(Light).enabled = false;
	GameObject.Find("Graphics").GetComponent(MeshRenderer).enabled = false;
	
	camera1.camera.enabled = false;
	camera2.camera.enabled = true;
	camera2.animation.Play();
	
	yield WaitForSeconds(animationDuration);
	cutScenePlaying = true;
	yield WaitForSeconds(5.0f);
	if(camera2.animation.isPlaying == false)
	{
		mainCameraSwitch();
	}
}


/*function moveBoxes() {
	boxPhysics.Explode();
}*/

function mainCameraSwitch() 
{
	camera1.camera.enabled = true;
	camera2.camera.enabled = false;
	GameObject.Find("Player").GetComponent(FPSInputController).enabled = true;
	GameObject.Find("Graphics").GetComponent(MeshRenderer).enabled = true;
	GameObject.Find("Flashlight").GetComponent(Light).enabled = false;
	cutScenePlaying = false;
}