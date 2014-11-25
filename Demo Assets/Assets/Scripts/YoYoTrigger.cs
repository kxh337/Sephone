using UnityEngine;
using System.Collections;

public class YoYoTrigger : MonoBehaviour {
	public AudioSource source;
	public AudioClip sound;
	private bool containsYoYo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			audio.Play();
			containsYoYo = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().InventoryContain(6);

		}
	}
}
