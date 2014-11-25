using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Texture2D mapSource;
	public int visionPercentage = 15;
	public float updateInterval = 1;
	public float markerWidth = 5;		//ALL SIZES ARE PERCENTWISE
	public float 	mapPosLeft = 8,
					mapPosTop = 30,
					mapWidth = 17;
	
	[HideInInspector]
	public Texture2D map;
	public Texture2D marker;
	[HideInInspector]
	public Rect mapTexPos;
	[HideInInspector]
	public Rect markerTexPos;

	Color32[] bitmap;
	int[] alphaOriginal;
	byte[,] alpha;
	float refWidth;
	float refHeight;
	int visionPixels;
	
	GameObject Player;
	Bounds refObjBounds;
	
	void Start() {
		setupMap ();

		mapTexPos = new Rect (mapPosLeft * Screen.width / 100, mapPosTop * Screen.height / 100, mapWidth * Screen.width/100, map.height * mapWidth * Screen.width / 100 / map.width);
		markerTexPos = new Rect (0, 0, mapTexPos.width / 100 * markerWidth, marker.width * mapTexPos.width / 100 * markerWidth / marker.height);

		Player = GameObject.FindWithTag("Player");
		refObjBounds = renderer.bounds;
		
		visionPixels = (map.height + map.width) / 200 * visionPercentage;
		refWidth = (refObjBounds.max.x - refObjBounds.min.x);
		refHeight =  (refObjBounds.max.z - refObjBounds.min.z);
		
		makeCircle ();
		InvokeRepeating("UpdateMap", 0, updateInterval);
	}

	
	void setupMap() {
		bitmap = mapSource.GetPixels32();
		alphaOriginal = new int[bitmap.Length];
		for (int i = 0; i < bitmap.Length; i++) {
			alphaOriginal[i] = bitmap[i].a;
			bitmap [i].a = 0;
		}
		
		map = new Texture2D(mapSource.width, mapSource.height);
		map.SetPixels32(bitmap);
		map.Apply();
	}
	
	void UpdateMap () {
		int x = Mathf.RoundToInt((Player.transform.position.x - refObjBounds.min.x) * map.width / refWidth);
		int y = Mathf.RoundToInt((Player.transform.position.z - refObjBounds.min.z) * map.height / refHeight);
		paintCircle (x, y);

		markerTexPos.x = mapTexPos.x + x * mapTexPos.width / map.width;
		markerTexPos.y = mapTexPos.y + mapTexPos.height - y * mapTexPos.height / map.height;
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
			int pos = y*map.width + x;
			if(pos < bitmap.Length && a > bitmap[pos].a)
				bitmap[pos].a = (byte) Mathf.Min(a, alphaOriginal[pos]);
		}
		map.SetPixels32 (bitmap);
		map.Apply ();
	}
}
