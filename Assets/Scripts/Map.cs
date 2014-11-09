using UnityEngine;
using System.Collections;

public class Map2 : MonoBehaviour {
	public Texture2D mapSource;
	public int width = 256;
	public int height = 256;
	public int visionPercentage = 3;
	
	Texture2D map;
	Color32[] bitmap;
	int[] alpha;
	float refWidth;
	float refHeight;
	Rect position;
	int visionPixels;

	Vector3 PlayerPos;
	Bounds refObjBounds;

	void Start() {
		if (mapSource == null) {
			mapSource = new Texture2D (width, height);
		}
		bitmap = mapSource.GetPixels32();
		PlayerPos = GameObject.FindWithTag ("Player").transform.position;

		map = new Texture2D(mapSource.width, mapSource.height);
		map.SetPixels32(bitmap);
		map.Apply();

		position = new Rect (0, 0, width, height);
		visionPixels = (map.height + map.width) / 200 * visionPercentage;
		refWidth = map.width / (refObjBounds.max.x - refObjBounds.min.x);
		refHeight = map.height / (refObjBounds.max.z - refObjBounds.min.z);

		makeCircle ();
	}

	void OnGUI() {
		GUI.DrawTexture (position, map);
	}

	void Update () {
		int x = Mathf.RoundToInt((PlayerPos.x - refObjBounds.min.x) * refWidth);
		int y = Mathf.RoundToInt((PlayerPos.z - refObjBounds.min.z) * refHeight);

		paintCircle (x, y);
	}

	void makeCircle() {
		int r = visionPixels/2;
		for(int x = 0; x < visionPixels; x++)
		for(int y = 0; y < visionPixels; y++) {
			float dx = x-r, dy=y-r;
			float dist = Mathf.Sqrt(dx*dx+dy*dy);
			
			alpha[y * x + x] = Mathf.Min(0, ((r - dist) / r * 255) );
		}
	}

	void paintCircle(int cx, int cy)
	{

	}
}
