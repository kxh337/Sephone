using UnityEngine;
using System.Collections;

public class GenericGhost : MonoBehaviour {
	public Transform player;
	public bool triggered;
	public float warningZone;
	public float warningZone1;
	public float killZone;
	public RedDead death;
	private float playerDist;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		checkDeathDist();
	}

	public void checkDeathDist(){
		if(playerDist < killZone){
			//kill player and respawn at last checkpoint
			death.danger3();
		}
		else if(playerDist < warningZone1){
			//more warning on screen with hard hearbeating
			death.danger2();
		}
		else if(playerDist < warningZone){
			//light warning and lighter heartbeating
			death.danger1();
		}
	}
}
