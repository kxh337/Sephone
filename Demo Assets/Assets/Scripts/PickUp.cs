using UnityEngine;
using System.Collections;


public class PickUp : MonoBehaviour {

	

	private float distance = 3.0F;
	private Inventory inv;


	void pickUpItem() 
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
		{
			if(hit.distance < distance)
			{
				inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
				CheckItem check = new CheckItem();
				hit.transform.SendMessage("setItemID", check, SendMessageOptions.DontRequireReceiver);
				inv.SendMessage("AddItem", check.itemID, SendMessageOptions.RequireReceiver);
				hit.transform.SendMessage("itemCollected", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	void Update() 
	{
		if (Input.GetButtonDown("Fire3")) 
		{
			pickUpItem();
		}
	}
}
