using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start() 
	{
		items.Add(new Item("pendant", 0, "An enchanted pendant", 2, 0, Item.ItemType.Quest));
		items.Add(new Item("shirt", 1, "A white shirt", 0, 0, Item.ItemType.Consumable));
	}
}
