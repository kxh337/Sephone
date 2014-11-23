using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Texture2D mapSource;
	Rect position;
	public int visionPercentage = 15;
	public float updateInterval = 1;
	public Texture2D tempMapCover;
	public Texture2D map;
	Color32[] bitmap;
	byte[,] alpha;
	float refWidth;
	float refHeight;
	int visionPixels;
	
	GameObject Player;
	Bounds refObjBounds;
	
	void Start() {
		setupMap ();
		//position = new Rect(Screen.width / 10, Screen.width / 8, Screen.width / 5, Screen.height / 2);
		position = new Rect(0, 0, 256, 256);
		Player = GameObject.FindWithTag("Player");
		refObjBounds = renderer.bounds;
		
		visionPixels = (map.height + map.width) / 200 * visionPercentage;
		refWidth = (refObjBounds.max.x - refObjBounds.min.x);
		refHeight =  (refObjBounds.max.z - refObjBounds.min.z);
		
		makeCircle ();
		InvokeRepeating("UpdateMap", 0, updateInterval);
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
}
