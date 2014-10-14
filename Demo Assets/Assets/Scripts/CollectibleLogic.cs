using UnityEngine;
using System.Collections;

public class CollectibleLogic : MonoBehaviour {
	public int itemID;
	//private PickUp picks;
	void itemCollected() 
	{
		//Could play sounds of item being picked up here, or trigger some event
		Destroy(gameObject);
		//picks = GameObject.FindGameObjectWithTag("Player").GetComponent<PickUp>();
		//picks.inventoryArray[0]++;
	}
	void setItemID(CheckItem item) 
	{
		item.itemID = this.itemID;
	}
}
