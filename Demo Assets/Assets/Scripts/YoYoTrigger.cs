using UnityEngine;
using System.Collections;

public class YoYoTrigger : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	private bool played;
	private bool containsYoYo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" && !played){
			audio.Play();
			//containsYoYo = GameObject.FindGameObjectWithTag("Inventory").SendMessage("InventoryContain", 6);
			played = true;
		}
	}
}
