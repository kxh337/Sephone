using UnityEngine;
using System.Collections;

public class ItemGlow : MonoBehaviour {
	public Light glow;
	public float glowSpeed;
	public float glowMin;
	public float glowMax;
	private float glowVal;
	private int glowDirection;
	// Use this for initialization
	void Start () {
		glowDirection = 1;
	}
	
	// Update is called once per frame
	void Update () {
		glowVal = glow.range;
		if(glowVal > glowMax){
			glowDirection = -1;
		}
		else if(glowVal < glowMin){
			glowDirection = 1;
		}
		glow.range =  glow.range + glowSpeed * glowDirection * Time.deltaTime;
	}
}
