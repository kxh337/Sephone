#pragma strict

static var InventoryArray : int[] = [1, 2, 0, 0, 0];
var inventoryText : GameObject;

function Update () {

	inventoryText.guiText.text = "Health Level: " + InventoryArray[0] + "\n" + "Battery Level: " + InventoryArray[1];
}