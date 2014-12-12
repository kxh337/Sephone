using UnityEngine;
using System.Collections;

public class RedDead : MonoBehaviour {
	public bool danger1;
	public bool danger2;
	public bool danger3;
	public Texture2D red1;
	public Texture2D red2;
	public Texture2D red3;
	public Texture2D black;
	public AudioSource source;
	public AudioClip beat;
	public AudioClip fasterbeat;
	public float flashSpeed;
	public float fadeSpeed;
	public float blackAlpha;
	public float warningZone;
	public float warningZone1;
	public float killZone;
	private Rect rect;
	private Color tempRed1;
	private Color tempRed2;
	private Color tempRed3;
	public bool played1;
	public bool played2;
	public bool played3;
	private int totem;
	private float alpha1;
	private float alpha2;
	private float alpha3;
	private int currentDanger;
	private int pastDanger;
	private bool dangertemp0;
	private bool dangertemp1;
	private bool dangertemp2;
	private bool dangertemp3;
	public float gameOverTime;
	public bool gameOver;
	public GenericGhost[] ghosts;
	public float blackValue;
	// Use this for initialization
	void Start () {
		rect = new Rect(0,0, Screen.width, Screen.height);
		source.loop = true;
		played1 = false;
		played2 = false;
		played3 = false;
		source.Stop();
		alpha1 = 0f;
		alpha2 = 0f;
		alpha3 = 0f;
		currentDanger = 0;
		pastDanger = 0;
		dangertemp1 =false;
		dangertemp2 =false;
		dangertemp3 =false;
		gameOver = false;
		blackValue = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time <= gameOverTime){
			blackValue -= Mathf.Clamp01(Time.deltaTime * fadeSpeed);
			Debug.Log("Black alpha is "+blackValue);
		}


		checkDeathDist();
		//totem = GameObject.Find("Totem").GetComponent<GamePause>().canPaused;
		if(!danger1 && !danger2 && !danger3){
			played1 = false;
			played2 = false;
			played3 = false;
			source.Stop();
		}
		if(danger1){
			if(!played1){
				source.Stop();
				source.clip = beat;
				source.Play();
				played1 = true;
			}
		}
		else{
			played1 = false;
		}
		if(danger2){
			if(!played2){
				source.Stop();
				source.clip = fasterbeat;
				source.Play();
				played2 = true;
			}
		}
		else{
			played2 = false;
		}
		if(danger3){
			if(!played3){
				source.Stop();
				source.clip = fasterbeat;
				source.Play();
				played3 = true;
				gameOver = true;
			}
		}
		else{
			played3 = false;

		}
	
	}

	public void checkDeathDist(){
		float minDist = ghosts[0].playerDist;

		foreach (GenericGhost ghost in ghosts) {
			if(ghost.playerDist == 0){
				//ignore it's not possible
			}
			else if(minDist > ghost.playerDist){
				minDist = ghost.playerDist;
			}
		}

			Debug.Log(minDist);
			
			if (minDist < killZone) {
				//kill player and respawn at last checkpoint
				danger3 = true;
				danger2 = false;
				danger1 = false;
			} else if (minDist < warningZone1) {
				//more warning on screen with hard hearbeating
				danger3 = false;
				danger2 = true;
				danger1 = false;
			} else if (minDist < warningZone) {
				//light warning and lighter heartbeating
				danger3 = false;
				danger2 = false;
				danger1 = true;
			} else {
				danger3 = false;
				danger2 = false;
				danger1 = false;
			}
	}

	void OnGUI(){
		if(totem == 0 || totem ==2){
			/*if(danger1 && pastDanger == 0 ){
				blinkTexture(red1,tempRed1,0f,.3f, alpha1,flashSpeed);
				Debug.Log("Danger 1");
				alpha2 = 0f;
				alpha3 = 0f;
			}
			else if (danger1 && pastDanger==2){
				blinkTexture(red1,tempRed1,.3f,0f, alpha1,flashSpeed);
				Debug.Log("Danger 1");
				alpha2 = 0f;
				alpha3 = 0f;
			}
			else if(danger2 && pastDanger == 1){
				blinkTexture(red1,tempRed1,.3f,.4f, alpha2,flashSpeed);
				Debug.Log("Danger 2");
				alpha1 = 0f;
				alpha3 = 0f;
			}
			else if (danger2 && pastDanger ==3){
				blinkTexture(red1,tempRed1,.4f,.3f, alpha2,flashSpeed);
				Debug.Log("Danger 2");
				alpha1 = 0f;
				alpha3 = 0f;
			}
			else if(danger3){
				blinkTexture(red1,tempRed1,.4f,.5f , alpha3, 10f);
				Debug.Log("Danger 3");
				alpha1 = 0f;
				alpha2 = 0f;
			}
<<<<<<< Updated upstream
			else{
				//Debug.Log("Safe");
=======
			else if(!danger1 && pastDanger == 1){
				Debug.Log("Safe");
				blinkTexture(red1,tempRed1,.3f,0f, alpha1,flashSpeed);
				alpha2 = 0f;
				alpha3 = 0f;
			}
			else{
				alpha1 = 0f;
				alpha2 = 0f;
				alpha3 = 0f;
>>>>>>> Stashed changes

			}*/
			if(danger1){
				blinkTexture(red1,.5f,.8f, alpha1,flashSpeed);
				alpha2 = 0f;
				alpha3 = 0f;
			}
			else if(danger2){
				blinkTexture(red2,.5f,.8f, alpha2,flashSpeed);
				alpha1 = 0f;
				alpha3 = 0f;
			}
			else if(danger3){
				blinkTexture(red3,.9f,1f, alpha3,flashSpeed);
				blinkTexture(black,.8f,1f,blackAlpha, fadeSpeed);
				alpha1 = 0f;
				alpha2 = 0f;
				gameOver = true;
				//blackValue = 1f;
			}
			else{
				alpha1 = 0f;
				alpha2 = 0f;
				alpha3 = 0f;
			}

			if(Time.time <= gameOverTime){
				GUI.color = new Color(1.0f, 1.0f, 1.0f, blackValue);
				GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),black);
				GUI.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				 
			}
			else{
				Debug.Log("Not Game Over");
				blackValue = 0f	;
			}
		}
	}

	void blinkTexture(Texture2D texture, float start, float end, float alpha,float speed){
		alpha = Mathf.Lerp(start,end,Time.time * speed);
		GUI.color = new Color(1f,1f,1f,alpha);
		GUI.DrawTexture(rect,texture);
	}

}
