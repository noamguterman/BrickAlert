using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag != "Ball" && collision.gameObject.name !="Paddle" && collision.gameObject.name != "Right Wall" && collision.gameObject.name !="Left Wall") {
			Time.timeScale = 0;
			GameController._instance.scorePanel.SetActive (true);
			GameController._instance.gameTapArea.SetActive (true);
			GameController._instance.ball1.GetComponent<Ball>().hasStarted = false;
			GameController._instance.ball2.GetComponent<Ball>().hasStarted = false;
			Globals.gameStarted = false;
		} 
	}

}
