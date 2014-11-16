using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Texture2D mapSource;
	public Rect position = new Rect(0, 0, 256, 256);
	public int visionPercentage = 10;
	public float updateInterval = 3;
	public Texture2D tempMapCover;
	Texture2D map;
	Color32[] bitmap;
	byte[,] alpha;
	float refWidth;
	float refHeight;
	int visionPixels;
//<<<<<<< HEAD
	public Texture2D backButton;
	public Texture2D backButtonGlow;

//=======
	
	GameObject Player;
	Bounds refObjBounds;
//>>>>>>> origin/master
	bool showMap = false;
	
	void Start() {
		setupMap ();
		
		Player = GameObject.FindWithTag("Player");
		refObjBounds = renderer.bounds;
		
		visionPixels = (map.height + map.width) / 200 * visionPercentage;
		refWidth = (refObjBounds.max.x - refObjBounds.min.x);
		refHeight =  (refObjBounds.max.z - refObjBounds.min.z);
		
		makeCircle ();
		InvokeRepeating("UpdateMap", 0, updateInterval);
	}
	
	void OnGUI() {
//<<<<<<< HEAD
		if(showMap) {
			Event ev = Event.current;
			//GUI.DrawTexture (position, map);
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
//=======
		//		if (showMap) {
		GUI.DrawTexture (position, map);
		//		}
//>>>>>>> origin/master
	}
	
	void setupMap() {
		if (mapSource == null) {
			mapSource = new Texture2D ((int)position.width, (int)position.height);
		}
		bitmap = mapSource.GetPixels32();
		for (int i = 0; i < bitmap.Length; i++)
			bitmap[i].a = 0;
		
		map = new Texture2D(mapSource.width, mapSource.height);
		map.SetPixels32(bitmap);
		map.Apply();
	}
	
	void UpdateMap () {
		int x = Mathf.RoundToInt((Player.transform.position.x - refObjBounds.min.x) * map.width / refWidth);
		int y = Mathf.RoundToInt((Player.transform.position.z - refObjBounds.min.z) * map.height /refHeight);
		paintCircle (x, y);
	}
	
	void makeCircle() {
		alpha = new byte[visionPixels,visionPixels];
		int r = visionPixels/2;
		for(int x = 0; x < visionPixels; x++)
		for(int y = 0; y < visionPixels; y++) {
			float dx = x-r, dy=y-r;
			float dist = Mathf.Sqrt(dx*dx+dy*dy);
			
			alpha[x,y] = (byte) Mathf.Max(0, 255 - (dist * 255 / r));
		}
	}
	
	//	void Update()
	//	{
	//		if(Input.GetButtonDown("map")) {
	//			showMap = !showMap;
	//		}
	//	}
	
	void paintCircle(int cx, int cy)
	{
		int r = visionPixels / 2;
		for(int x= cx - r; x < cx+r; x++)
		for(int y= cy - r; y < cy+r; y++) {
			byte a = alpha[x - (cx - r), y - (cy - r)];
			if(a > bitmap[y*map.width + x].a)
				bitmap[y*map.width + x].a = a;
		}
		map.SetPixels32 (bitmap);
		map.Apply ();
	}
	
	public void turnMapOn() {
		showMap = true;
	}
	public void turnMapOff() {
		showMap = false;
	}
}
