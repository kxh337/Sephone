using UnityEngine;
using System.Collections;

public class GhostB : GenericGhost {
	public Transform throughWall;
	public Transform endSpot;
	public float walkTime;
	public float smooth;
	private float endWalk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		playerDist = Vector3.Distance(player.transform.position,gameObject.transform.position);
		if(!triggered){
			endWalk = Time.time + walkTime;
		}
		if(triggered){
			transform.position = Vector3.Lerp(transform.position, throughWall.position, smooth * Time.deltaTime);
			if(Time.time > endWalk){
				transform.position = endSpot.position;
			}
		}
	}
}
