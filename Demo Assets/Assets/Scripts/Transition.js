#pragma strict

var alphaValue : float;
var controls : Texture2D;
var blackTexture : Texture2D;
function Start () {
	alphaValue = 0.0f;
}

function Update () {
	alphaValue += Mathf.Clamp01(Time.deltaTime / 10); 
}

function OnGUI() 
{
	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), controls);
	GUI.color = new Color(1.0f, 1.0f, 1.0f, alphaValue);
	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
	GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	if (alphaValue >= 1.0f)
	{
		Application.LoadLevel(2);
	}
}