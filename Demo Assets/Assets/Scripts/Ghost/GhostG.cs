using UnityEngine;
using System.Collections;

public class GhostG : GenericGhost {
	public AIPathFinder finder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerDist = Vector3.Distance(player.transform.position,gameObject.transform.position);
		baseUpdate (playerDist);
		//finder.entered = triggered;
	}
}
