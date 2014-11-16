using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Texture2D mapSource;
	public Texture2D mapCoverSource;
	//public int width = Screen.width / 3;
	//public int height = Screen.height;
	public int visionPercentage = 3;
	
	Texture2D map;
	Texture2D mapCover;
	float refWidth;
	float refHeight;
	Rect position;
	int visionPixels;
	public Texture2D backButton;
	public Texture2D backButtonGlow;

	bool showMap = false;

	void Start() {

		int width = Screen.width / 3;
		int height = Screen.height;
		if (mapSource == null) {
			mapSource = new Texture2D (width, height);
		}
		if (mapCoverSource == null) {
			mapCoverSource = new Texture2D (width, height);
		}

		map = new Texture2D(mapSource.width, mapSource.height);
		map.SetPixels32(mapSource.GetPixels32());
		map.Apply();
		
		mapCover = new Texture2D(mapCoverSource.width, mapCoverSource.height);
		mapCover.SetPixels32(mapCoverSource.GetPixels32());
		mapCover.Apply();

		position = new Rect (0, 0, width, height);
		visionPixels = (mapCover.height + mapCover.width) / 200 * visionPercentage;

		refWidth = renderer.bounds.max.x - renderer.bounds.min.x;
		refHeight = renderer.bounds.max.z - renderer.bounds.min.z;
		InvokeRepeating("UpdateMap", 0.0f, 0.5f);
	}

	void OnGUI() {
		if(showMap) {
			Event ev = Event.current;
			//GUI.DrawTexture (position, map);
			GUI.DrawTexture (position, mapCover);
			Rect buttonArea = new Rect(Screen.width / 23, Screen.height / 19, backButton.width, backButton.height);
			GUI.DrawTexture(buttonArea, backButton);
			if(buttonArea.Contains(ev.mousePosition))
			{
				GUI.DrawTexture(buttonArea, backButtonGlow);
			}
			if(buttonArea.Contains(ev.mousePosition) && ev.isMouse && ev.type == EventType.mouseUp)
			{
				showMap= false;
				GameObject.Find("Inventory").GetComponent<Inventory>().playNotebookFlipSound();
				GameObject.Find("Inventory").GetComponent<Inventory>().backToInvTab();
			}
			/*if(GUI.Button(new Rect(0, 0, Screen.width / 10, Screen.height / 12), "Back"))
			{
				showMap= false;
				GameObject.Find("Inventory").GetComponent<Inventory>().playNotebookFlipSound();
				GameObject.Find("Inventory").GetComponent<Inventory>().backToInvTab();
			}*/
		}
	}
	void Update()
	{
		/*if(Input.GetButtonDown("map")) {
			audio.Play();
			showMap = (true && !showMap);
		}*/
	}
	void UpdateMap () {

		float px = GameObject.FindWithTag("Player").transform.position.x - renderer.bounds.min.x;
		int x = Mathf.RoundToInt(px * mapCover.width / refWidth);
		float pz = GameObject.FindWithTag("Player").transform.position.z - renderer.bounds.min.z;
		int y = Mathf.RoundToInt(pz * mapCover.height / refHeight);

		//paintCircle (mapCover, 50, 50, visionPixels, Color.clear);
		//paintCircle (mapCover, 50, 50, visionPixels / 3, Color.red);
	}

	void paintCircle(Texture2D tex, int cx, int cy, int r, Color col)
	{
		for(int x= cx - r; x < cx+r; x++)
		for(int y= cy - r; y < cy+r; y++) {
			
			float dx = x-cx, dy=y-cy;
			float dist = Mathf.Sqrt(dx*dx+dy*dy);
			
			if(dist<r)
				tex.SetPixel(x, y, col);
		}

		tex.Apply ();
	}

	public void turnMapOn() {
		showMap = true;
	}
	public void turnMapOff() {
		showMap = false;
	}
}
