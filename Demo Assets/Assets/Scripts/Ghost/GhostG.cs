using UnityEngine;
using System.Collections;

public class GhostG : GenericGhost {
	public AIPathFinder finder;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		baseUpdate ();
		finder.entered = triggered;
	}
}
