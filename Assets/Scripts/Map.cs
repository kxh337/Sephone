using UnityEngine;
using System.Collections;

public class Map : MonoBehaviour {
	public Texture2D mapSource;
	public Rect position = new Rect(0, 0, 256, 256);
	public int visionPercentage = 3;
	public float updateInterval = 3;
	
	Texture2D map;
	Color32[] bitmap;
	int[] alpha;
	float refWidth;
	float refHeight;
	int visionPixels;
	
	Vector3 PlayerPos;
	GameObject Player;
	Bounds refObjBounds;
	
	void Start() {
		if (mapSource == null) {
			mapSource = new Texture2D ((int)position.width, (int)position.height);
		}
		bitmap = mapSource.GetPixels32();
		PlayerPos = GameObject.FindWithTag("Player").transform.position;
		Player = GameObject.FindWithTag("Player");
		refObjBounds = renderer.bounds;

		clearBitmap();

		map = new Texture2D(mapSource.width, mapSource.height);
		map.SetPixels32(bitmap);
		map.Apply();

		visionPixels = (map.height + map.width) / 200 * visionPercentage;
		alpha = new int[visionPixels * visionPixels];
		refWidth = (refObjBounds.max.x - refObjBounds.min.x);
		refHeight =  (refObjBounds.max.z - refObjBounds.min.z);
		
		makeCircle ();
		InvokeRepeating("UpdateMap", 0, updateInterval);
	}
	
	void OnGUI() {
		GUI.DrawTexture (position, map);
	}

	void clearBitmap() {

	}
	
	void UpdateMap () {
		int x = Mathf.RoundToInt((Player.transform.position.x - refObjBounds.min.x) * map.width / refWidth);
		int y = Mathf.RoundToInt((Player.transform.position.z - refObjBounds.min.z) * map.height /refHeight);
//		print (x);
//		print (y);
		paintCircle (x, y);
	}
	
	void makeCircle() {
		int r = visionPixels/2;
		for(int x = 0; x < visionPixels; x++)
		for(int y = 0; y < visionPixels; y++) {
			float dx = x-r, dy=y-r;
			float dist = Mathf.Sqrt(dx*dx+dy*dy);
			
			alpha[y * x + x] = Mathf.RoundToInt( Mathf.Min(0.0f, ((r - dist) / r * 255) ));
		}
	}
	
	void paintCircle(int cx, int cy)
	{
		for (int y = Mathf.Min (0, cy - visionPixels / 2), ay = cy - y;
		     y < map.height && ay < visionPixels;
		     y += map.width, ay++) {
			for (int x = Mathf.Min (0, cx - visionPixels / 2), ax = cx - x;
			     x < bitmap.Length && ax < visionPixels;
			     x++, ax++) {
				print (y + " " + x + " " + ay + " " + ax );
				bitmap[y + x].a = (byte) alpha[ay + ax];
			}
		}
		map.SetPixels32 (bitmap);
		map.Apply ();
	}
}
