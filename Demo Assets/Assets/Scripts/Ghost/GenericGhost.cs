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
		playerDist = Vector3.Distance(player.transform.position,gameObject.transform.position);
		if(playerDist < killZone){
			//kill player and respawn at last checkpoint
			death.danger3 = true;
			death.danger2 = false;
			death.danger1 = false;
		}
		else if(playerDist < warningZone1){
			//more warning on screen with hard hearbeating
			death.danger3 = false;
			death.danger2 = true;
			death.danger1 = false;
		}
		else if(playerDist < warningZone){
			//light warning and lighter heartbeating
			death.danger3 = false;
			death.danger2 = false;
			death.danger1 = true;
		}
		else{
			death.danger3 = false;
			death.danger2 = false;
			death.danger1 = false;
		}
	}
}
