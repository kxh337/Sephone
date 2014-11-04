using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start() 
	{
		items.Add(new Item("pendant", 1, "An enchanted pendant", Item.ItemType.Quest));
		items.Add(new Item("shirt", 2, "A white shirt", Item.ItemType.Consumable));
	}
}
