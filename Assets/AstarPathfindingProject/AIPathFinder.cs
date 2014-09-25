using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPathFinder : MonoBehaviour {
	public Transform target;
	Seeker seeker;
	Path path;
	int currentWaypoint;
	public float speed = 20;
	public float wayPointDist = 2f;
	CharacterController charctlr;
	public float waitTime;
	float curTime;
	public Transform player;

	// Use this for initialization
	void Start () {
		curTime = Time.time;
		Physics.IgnoreCollision(transform.collider, player.collider);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > curTime+waitTime){
			seeker = GetComponent<Seeker>();
			seeker.StartPath(transform.position,target.transform.position,OnPathComplete);
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
