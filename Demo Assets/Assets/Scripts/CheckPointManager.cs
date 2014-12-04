using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {
	public CheckPoint[] points;
	public RedDead death;
	private Transform currentCheckPoint;
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateCheckPoint();
		if(death.gameOver){
			player.transform.position = currentCheckPoint.position;
		}
	}

	void updateCheckPoint(){
		foreach(CheckPoint point in points){
			if(point.activated){
				currentCheckPoint = point.gameObject.transform;
			}
		}
	}
}
