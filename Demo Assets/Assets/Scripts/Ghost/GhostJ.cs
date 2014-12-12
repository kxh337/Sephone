using UnityEngine;
using System.Collections;

public class GhostJ : GenericGhost {
	public bool roomExited;
	public Transform point1;
	public Transform point2;
	public Transform point3;
	public Transform point4;
	public float minDist;
	public float speed;
	public float pointDist;
	private Transform nextPoint;
	public Renderer render;

	// Use this for initialization
	void Start () {
		nextPoint = point1;
	}
	
	// Update is called once per frame
	void Update () {
		playerDist = Vector3.Distance(player.transform.position,gameObject.transform.position);
		if(triggered){
			move();
		}
		if(roomExited){
			transform.position = point4.position;
			renderer.enabled = true;
		}
	}

	void move(){
		if(Vector3.Distance(transform.position, player.position) > minDist){
			//have it turn towards the player and play audio maybe
		}
		else{
			Vector3 dir = nextPoint.position - transform.position;
			transform.Translate(dir / dir.magnitude *speed * Time.deltaTime); 
		}
		if(Vector3.Distance(transform.position, point1.position)< pointDist){
			nextPoint = point2;
		}
		else if(Vector3.Distance(transform.position, point2.position)< pointDist){
			nextPoint = point3;
		}
		else if (Vector3.Distance(transform.position, point3.position)< pointDist) {
			nextPoint = point4;
		}
		else if(Vector3.Distance(transform.position, point4.position) < pointDist){
			gameObject.SetActive(false); 
		}
	}
}
