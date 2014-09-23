#pragma strict

var onLadder : int = 0;
function OnTriggerEnter(col : Collider) 
{
	onLadder = 1;
}

function OnTriggerExit(col : Collider) 
{
	onLadder = 0;
}

function Update() 
{
	if(onLadder == 1 && Input.GetKey(KeyCode.X))
	{
		//GameObject.Find
	}
}