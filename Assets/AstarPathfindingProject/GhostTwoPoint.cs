using UnityEngine;
using System.Collections;
using Pathfinding;

public class GhostTwoPoint : MonoBehaviour {

	private Vector3 target;
	Seeker seeker;
	Path path;
	int currentWaypoint;
	public float speed;
	public float wayPointDist;
	CharacterController charctlr;
	public float waitTime;
	float curTime;
	public Transform player;
	public Transform pointA;
	public Transform pointB;
	private float dist;
	private Vector3 yPLayerPosition;
	private bool sighted;
	private bool atA;
	private bool atB;
	private float sightDistance;
	
	// Use this for initialization
	void Start () {
		curTime = Time.time;
		//		Physics.IgnoreCollision(transform.collider, player.collider);
		dist = 1;
	}
	
	// Update is called once per frame
	void Update () {
	

		dist = Vector3.Distance(transform.position,target);
		if(Time.time > curTime+waitTime){
			seeker = GetComponent<Seeker>();
			seeker.StartPath(transform.position,target,OnPathComplete);
			charctlr = GetComponent<CharacterController>();
			curTime = Time.time;
		}
	}
	
	public void OnPathComplete(Path p){
		if(!p.error){
			path = p;
			currentWaypoint = 0	;
		}
		else{
			
		}
		
	}
	
	public Vector3 getLastWP() {
		return path.vectorPath [currentWaypoint - 2];
	}
	
	void FixedUpdate(){
		speed = dist/1500;
		if(path == null){
			return;
		}
		if(currentWaypoint >=path.vectorPath.Count){
			return;
		}
		Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized * speed;
		charctlr.Move(dir);
		if(Vector3.Distance(transform.position,path.vectorPath[currentWaypoint]) < wayPointDist){
			currentWaypoint++;
		}
	}

}
