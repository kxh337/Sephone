#pragma strict

function OnCollisionEnter(collider:Collision)
{
	if(collider.gameObject.tag == "Cube") 
	{
		Inventory.InventoryArray[0]++;
		Destroy(collider.gameObject);
	}
}

function Update () {

}