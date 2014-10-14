using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

	public GUISkin skin;
	public int slotX, slotY;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	private ItemDatabase database;
	private bool showInventory = false;
	private bool showTooltip;
	private string tooltip;
	private bool dragItem;
	private Item itemDragged;
	private int prevIndex;
	public Texture2D invTexture;



	// Use this for initialization
	void Start () {
		for(int i = 0; i < slotX * slotY; i++) 
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

	}
	
	void Update() 
	{
		int canPause = GameObject.Find("Totem").GetComponent<GamePause>().canPaused;
		if (Input.GetButtonDown("Inventory") && (canPause == 0 || canPause == 2))
		{
			showInventory = !showInventory;
			togglePause();
		}
	}

	void OnGUI() 
	{
		tooltip = "";
		GUI.skin = skin;
		if(showInventory && Time.timeScale == 0) 
		{
			DrawInventory();
			if(showTooltip && tooltip != "")
			{
				GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 150, 100), tooltip, skin.GetStyle("tooltip"));
			}
		}
		if(dragItem) 
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 70, 70), itemDragged.itemIcon);
		}

	}

	void DrawInventory() 
	{
		Event e = Event.current;
		int i = 0;
		GUI.DrawTexture(new Rect(0, 0, (Screen.width / 3), (Screen.height)), invTexture); 
		for(int y = 0; y < slotY; y++)
		{
			for(int x = 0; x < slotX; x++)
			{
				Rect slotRect = new Rect(x * 75 + 160, y * 75 + 150, 70, 70);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));

				slots[i] = inventory[i];
				if(slots[i].itemName != null) 
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					if(slotRect.Contains(e.mousePosition))
					{
						CreateTooltip(slots[i]);
						showTooltip = true;
						if(e.button == 0 && e.type == EventType.mouseDrag && !dragItem)
						{
							dragItem = true;
							prevIndex = i;
							itemDragged = slots[i];
							inventory[i] = new Item();
						}
						if(e.type == EventType.mouseUp && dragItem) 
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = itemDragged;
							dragItem = false;
							itemDragged = null;
						}
					}
				}
				else 
				{
					if(slotRect.Contains(e.mousePosition))
					{
						if(e.type == EventType.mouseUp && dragItem) 
						{
							inventory[i] = itemDragged;
							dragItem = false;
							itemDragged = null;
						}
					}
				}
				i++;
			}
		}
	}

	string CreateTooltip(Item item) 
	{
		tooltip = "         "  + item.itemName + "\n\n" + "  " + item.itemDescription;
		return tooltip;
	}

	void RemoveItem(int id) 
	{
		for(int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id) 
			{
				inventory[i] = new Item();
				break;
			}
		}
	}
	void AddItem(int id) 
	{
		for(int i = 0; i < inventory.Count; i++) 
		{
			if(inventory[i].itemID == id)
			{
				break;
			}
			if(inventory[i].itemName == null) 
			{
				for(int j = 0; j < database.items.Count; j++)
				{
					if(database.items[j].itemID == id) 
					{
						inventory[i] = database.items[j];
						break;
					}
				}
				break;
			}
		}
	}
	bool InventoryContain(int id)
	{
		bool result = false;
		for(int i = 0; i < inventory.Count; i++)
		{
			result = inventory[i].itemID == id;
			if(result)
			{
				break;
			}
		}
			return result;
	}
	bool togglePause() 
	{
		if(Time.timeScale == 0)
		{
			GameObject.Find("Totem").GetComponent<GamePause>().canPaused = 0;
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = true;
			Screen.lockCursor = true;
			Time.timeScale = 1;
			return false;
		}
		else
		{
			GameObject.Find("Totem").GetComponent<GamePause>().canPaused = 2;
			GameObject.FindGameObjectWithTag("Player").GetComponent<MouseLook>().enabled = false;
			Screen.lockCursor = false;
			Time.timeScale = 0;
			return true;
		}
	}

}
