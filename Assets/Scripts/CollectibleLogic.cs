using UnityEngine;
using System.Collections;

public class CollectibleLogic : MonoBehaviour {

	void itemCollected() 
	{
		//Could play sounds of item being picked up here, or trigger some event
		Destroy(gameObject);
	}
}
