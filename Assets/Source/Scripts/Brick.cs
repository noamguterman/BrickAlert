using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		//isBreakable = (this.tag == "BreakableRed");
		// Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		
		timesHit = 0;
		//levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	

	
	void OnCollisionEnter2D (Collision2D col) {
		//AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
		if (col.gameObject.tag == "Ball") {
			GameObject obj = Instantiate (GameController._instance.brustFab);
			obj.transform.localPosition =  gameObject.transform.position;
			HandleHits();
		}

	}
	
	void HandleHits () {
		////timesHit++;
		////int maxHits = hitSprites.Length + 1;
		////if (timesHit >= maxHits) {
			///breakableCount--;
			//levelManager.BrickDestoyed();
			////PuffSmoke();
		//Debug.Log("Globals.totpoints >>" +Globals.totpoints);
		//Debug.Log("Globals.totpoints >>" +Globals.points);
		if (Globals.totpoints > Globals.points) {
			Globals.points++;
			if (PlayerPrefs.GetInt ("bestscore") < Globals.points) {
				PlayerPrefs.SetInt ("bestscore", Globals.points);
			}
			GameController._instance.scoreTxt.text = Globals.points.ToString ();
			GameController._instance.scorePanel_scoretxt.text = PlayerPrefs.GetInt ("bestscore").ToString ();
			Destroy (gameObject);
			Resources.UnloadUnusedAssets ();
			//Debug.Log ("Points:" + Globals.points);
		} else {
			GameController._instance.GameStop ();

		}
		///} else {
			///LoadSprites();
		///}
	}
	
	void PuffSmoke () {
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError ("Brick sprite missing");
		}
	}
	
	// TODO Remove this method once we can actually win!
	void SimulateWin () {
		Debug.Log ("Gandu.........");
		//levelManager.LoadNextLevel();
	}
}
