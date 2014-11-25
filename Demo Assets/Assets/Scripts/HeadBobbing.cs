using UnityEngine;
using System.Collections;

public class HeadBobbing : MonoBehaviour {
	private float timer = 0.0F; 
	public float bobbingSpeed = 0.1F; 
	public float bobbingAmount = 0.09F; 
	//public float midpoint = 2.0F;
	private float midpoint;

	void Start() {
		midpoint = transform.localPosition.y + bobbingAmount;

	}

	// Update is called once per frame
	void Update () {
		float waveslice = 0.0F; 
		float horizontal = Input.GetAxis("Horizontal"); 
		float vertical = Input.GetAxis("Vertical"); 
		if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) { 
			timer = 0.0F;
		} 
		else { 
			waveslice = Mathf.Sin(timer); 
			timer = timer + bobbingSpeed; 
			if (timer > Mathf.PI * 2) { 
				timer = timer - (Mathf.PI * 2); 
			} 
		} 
		if (waveslice != 0) { 
			float translateChange = waveslice * bobbingAmount; 
			float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
			totalAxes = Mathf.Clamp (totalAxes, 0.0F, 1.0F); 
			translateChange = totalAxes * translateChange;
			transform.localPosition = new Vector3(translateChange,
		                                        midpoint - Mathf.Abs(translateChange),
			                                    0);
		} 
		else {
			transform.localPosition = new Vector3(0,
			                                      midpoint,
			                                      0);
		} 
	
	}
}