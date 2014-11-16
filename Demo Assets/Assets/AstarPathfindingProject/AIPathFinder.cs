﻿using UnityEngine;
using System.Collections;
using Pathfinding;

public class AIPathFinder : MonoBehaviour {
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
	public float repathDist;
	public float yOffset;
	private float dist;
	private Vector3 yPLayerPosition;

	// Use this for initialization
	void Start () {
		curTime = Time.time;
//		Physics.IgnoreCollision(transform.collider, player.collider);
		dist = 1;
	}
	
	// Update is called once per frame
	void Update () {
		target = player.position +  (Vector3)(Random.insideUnitCircle*2) +Vector3.back; 
		dist = Vector3.Distance(transform.position,target);
		if(Time.time > curTime+waitTime && dist >= repathDist){
			seeker = GetComponent<Seeker>();
			seeker.StartPath(transform.position,target,OnPathComplete);
			charctlr = GetComponent<CharacterController>();
			curTime = Time.time;
		}
		//transform.position = new Vector3(transform.position.x,player.position.y + yOffset,transform.position.z);
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
		speed = dist/150;
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