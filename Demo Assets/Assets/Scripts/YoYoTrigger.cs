using UnityEngine;
using System.Collections;

public class YoYoTrigger : MonoBehaviour {
	public GameObject sephone;
	public AudioSource source;
	public AudioClip sound;
	public bool played = false;
	private bool containsYoYo;
	private bool showPrompt = false;
	public GUISkin skin;
	private Event ev;

	// Use this for initialization
	void Start () {
		sephone.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (played) {
			sephone.SetActive(true);
		}
		//Event ev = Event.current;
		if(showPrompt)
		{

			if(ev != null)
				Debug.Log(ev);
			if(ev != null && ev.isMouse && ev.type == EventType.mouseUp && ev.button == 0 && !played) 
			{
				
				GameObject.Find("GhostG").SetActive(false);
				GameObject.Find("pickupYoyo").GetComponent<MeshRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().RemoveItem(6);
				played = true;
				showPrompt = false;
			}
		}
	}

	void OnGUI() 
	{
		if(showPrompt)
		{
			ev = Event.current;
			GUI.skin = skin;
			GUI.Label(new Rect((Screen.width - Screen.width / 3) / 2, Screen.height * 0.95f, Screen.width / 3, Screen.height / 10),
		          "Left Click to place Yoyo");
		}
	}

	void OnTriggerEnter(Collider other){
		containsYoYo = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().InventoryContain(6);
		if(other.gameObject.tag == "Player" && containsYoYo){
			showPrompt = true;

			//audio.Play();



		}
	}
	void OnTriggerExit(Collider other) 
	{
		if(other.gameObject.tag == "Player")
		{
			showPrompt = false;
		}
	}

	public bool getPrompt()
	{
		return played;
	}
}
