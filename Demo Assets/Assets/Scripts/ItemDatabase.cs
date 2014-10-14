using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

	public List<Item> items = new List<Item>();

	void Start() 
	{
		items.Add(new Item("Hairclip", 1, "Found on the ground", Item.ItemType.Quest));
		items.Add(new Item("Jacks", 2, "Part of a puzzle", Item.ItemType.Quest));
		items.Add(new Item("Note", 3, "A doctor's note", Item.ItemType.Quest));
	}
}
