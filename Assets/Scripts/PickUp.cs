using UnityEngine;
using System.Collections;


public class PickUp : MonoBehaviour {


	private int[] inventoryArray = {1};
	public GameObject inventoryText;
	private float distance = 3.0F;


	void pickUpItem() 
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
		{

			if(hit.distance < distance)
			{
				inventoryArray[0]++;
				hit.transform.SendMessage("itemCollected", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	void Update() 
	{
		inventoryText.guiText.text = "Cubes Collected: " + inventoryArray[0];
		if (Input.GetButtonDown("Fire1")) 
		{

			pickUpItem();
		}
	}
}
