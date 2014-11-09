using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
	public float volume;
	// Use this for initialization
	void Start () {
		InvokeRepeating("UpdateSound", 0.0f, 0.1f);
	}

	void UpdateSound() 
	{
		CharacterController controller = GetComponent<CharacterController>();
		if(controller.velocity.sqrMagnitude != 0 && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
		{
			audio.enabled = true;
			audio.volume = volume;
			audio.loop = true;
		}
		else{
			audio.enabled = false;
			audio.volume = 0.0f;
			audio.loop = false;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
