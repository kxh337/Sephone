using UnityEngine;
using System.Collections;

public class CollectibleLogic : MonoBehaviour {
	public int itemID;
	public string itemName;

	void itemCollected() 
	{
		//Could play sounds of item being picked up here, or trigger some event
		Destroy(gameObject);
	}
	void setItemID(CheckItem item) 
	{
		item.itemID = this.itemID;
	}

	void setItemName(CheckItem item)
	{
		item.itemName = this.itemName;
	}


	/*void OnGUI()
	{
		if(isPickUpable)
		{
			int textWidth = 250;
			int textHeight = 50;
			GUI.Label(new Rect((Screen.width / 2) - (textWidth / 2), (Screen.height / 1.2f) - (textHeight / 2), textWidth, 
			                   textHeight), "Left click to pick up " + itemName);
		}
	}

	void OnTriggerEnter(Collider col) 
	{
		if(col.tag == "Player")
		{
			isPickUpable = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Player")
		{
			isPickUpable = false;
		}
	}*/
}
