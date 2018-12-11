using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void clock_press(){
		Globals.isClockStarted = true;
		Invoke ("clockStart", Globals.clockTime);
	}
	public void ballspeed_click(){
		
	}
	public void balladded_click(){
		GameObject ball = Instantiate (GameController._instance.ballprefab);
		ball.transform.position = new Vector3 (8f, 6f, 0);
		ball.GetComponent<Ball> ().onInitialStart ();
	}
	public void wallsize_click(){
		Debug.Log ("-----incrSize_click-----");
		Paddle._inst.incrSize_click ();

	}

	void clockStart(){
		Globals.isClockStarted = false;
	}
}
