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
		checkItemProximity();
		if (Input.GetButtonDown("Fire3")) 
		{
			pickUpItem();
		}


	}

	void checkItemProximity()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
		{
			if(hit.distance < distance) 
			{
				CheckItem check = new CheckItem();
				hit.transform.SendMessage("setItemName", check, SendMessageOptions.DontRequireReceiver);
				int textWidth = 250;
				int textHeight = 50;
				GUI.Label(new Rect((Screen.width / 2) - (textWidth / 2), (Screen.height / 1.2f) - (textHeight / 2), textWidth, 
				                   textHeight), "Left click to pick up " + check.itemName);
			}
		}
	}
}
