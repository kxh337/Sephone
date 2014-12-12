using UnityEngine;
using System.Collections;

public class GhostBvocal : MonoBehaviour {
	public AudioClip[] clips;
	public AudioSource source;
	public GhostB ghost;
	private float dist;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		dist = ghost.playerDist;
		if(dist < 14f){

		}
		else if(dist < 9f) {

		}
		else if(dist < 4) {

		}
		else{

		}
	}
}
