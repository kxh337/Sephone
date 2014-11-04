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
	bool showNote = false;
	public Texture2D currentNote;
	public Vector2 scrollPosition = Vector2.zero;



	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
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
			audio.Play();
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
				float dynamicSize = skin.box.CalcHeight(new GUIContent(tooltip), 200);
				GUI.Box(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 200, dynamicSize + 10), tooltip, skin.GetStyle("tooltip"));
			}
		}
		if(dragItem) 
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 70, 70), itemDragged.itemIcon);
		}
		if(showNote && currentNote != null)
		{
			int noteWidth = currentNote.width;
			int noteHeight = currentNote.height;
			scrollPosition = GUI.BeginScrollView(new Rect((Screen.width - Screen.width / 3) / 2, 0.0f, Screen.width / 3,
			                                              Screen.height), scrollPosition, 
			                                     new Rect((Screen.width - Screen.width / 3) / 2, -150, noteWidth, noteHeight));

			GUI.DrawTexture(new Rect((Screen.width - noteWidth) / 2, (Screen.height - noteHeight) / 2,
			                         noteWidth, noteHeight), currentNote);

			GUI.EndScrollView();
		}
	}

	void DrawInventory() 
	{
		//this.audio.PlayOneShot(notebookFlip, 1.0f);


		Event e = Event.current;
		int i = 0;
		GUI.DrawTexture(new Rect(0, 0, (Screen.width / 3), (Screen.height)), invTexture); 
		for(int y = 0; y < slotY; y++)
		{
			for(int x = 0; x < slotX; x++)
			{
				Rect slotRect = new Rect(x * (Screen.width / 17) + (Screen.width / 10), y * (Screen.width / 17) + (Screen.width / 8), (Screen.width / 20), (Screen.width / 20));
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));

				slots[i] = inventory[i];
				//For each slot that has an item in it, draw it
				if(slots[i].itemName != null) 
				{
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
					//Checks if the user places the mouse above a item slot that is currently being drawn
					if(slotRect.Contains(e.mousePosition) && !showNote)
					{
						//Create and show the tooltip
						CreateTooltip(slots[i]);
						showTooltip = true;
						//If the user is dragging the mouse over this slot, then we draw the item icon beneath the cursor
						if(e.button == 0 && e.type == EventType.mouseDrag && !dragItem)
						{
							dragItem = true;
							prevIndex = i;
							itemDragged = slots[i];
							inventory[i] = new Item();
						}

						//If the user releases the previously dragged item over a slot that contains an item,
						//swap the two item slots
						if(e.type == EventType.mouseUp && dragItem) 
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = itemDragged;
							dragItem = false;
							itemDragged = null;
						}
					}
					if(tooltip == "")
					{
						showTooltip = false;
					}
					//Show the note if the user left-double-clicks a readable item

					if(e.isMouse && e.button == 0 && e.clickCount == 2)
					{
						showNote = true;
						currentNote = slots[i].noteTexture;
					}
					if(showNote) {


						if(e.isMouse && e.button == 1 && e.clickCount == 2)
							showNote = false;
					}
				}
				else 
				{
					//In the case when the user positions the mouse above an empty slot
					if(slotRect.Contains(e.mousePosition))
					{
						//If the user was previously dragging an item, then drop the item into the empty slot here
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
		tooltip = "<color=#0000FF>"  + item.itemName + "</color>\n\n" + "<color=#663300>" + item.itemDescription + "</color>";
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
