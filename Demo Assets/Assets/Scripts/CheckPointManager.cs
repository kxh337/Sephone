using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour {
	public CheckPoint[] points;
	public RedDead death;
	private CheckPoint currentCheckPoint;
	public GameObject player;
	public float setGameOverTime;
	// Use this for initialization
	void Start () {
		currentCheckPoint = points[0];
	}
	
	// Update is called once per frame
	void Update () {
		updateCheckPoint();
		if(death.gameOver){

			//player.rigidbody.velocity = Vector3.zero;
			player.transform.position = currentCheckPoint.gameObject.transform.position;
			player.transform.rotation = currentCheckPoint.gameObject.transform.rotation;
			death.gameOverTime = Time.time + setGameOverTime;
			death.gameOver = false;
			death.blackValue = 1f;
			//Debug.Log("Game over time" + death.gameOverTime	);
		}
	}

	void updateCheckPoint(){
		foreach(CheckPoint point in points){
			if(point.activated && point.value > currentCheckPoint.value){
				currentCheckPoint = point;
			}
		}
	}
}
