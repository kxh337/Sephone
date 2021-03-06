﻿#pragma strict

var camera1 : Camera;
var camera2 : Camera;

private var boxPhysics : BoxPhysics;

function Start() {
	GameObject.Find("Player").GetComponent(FPSInputController).enabled = false;
	GameObject.Find("Graphics").GetComponent(MeshRenderer).enabled = false;
	camera1.camera.enabled = false;
	camera2.camera.enabled = true;
	camera2.animation.Play();
	
	boxPhysics = GameObject.Find("ExplosionOrigin").GetComponent(BoxPhysics);
	
	yield WaitForSeconds(2);
	moveBoxes();
}	


function moveBoxes() {
	boxPhysics.Explode();
}

function mainCameraSwitch() 
{
	camera1.camera.enabled = true;
	camera2.camera.enabled = false;
	GameObject.Find("Player").GetComponent(FPSInputController).enabled = true;
	GameObject.Find("Graphics").GetComponent(MeshRenderer).enabled = true;
}