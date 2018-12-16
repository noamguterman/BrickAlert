using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject ball1;
	public GameObject ball2;
	public GameObject scorePanel;
	public Text scorePanel_scoretxt;
	public Text scoreTxt;
	public GameObject upperRowPanel;
	public GameObject lowerRowPanel;
	public Button clockBtn;
	public Button ballSpeedUpBtn;
	public Button addBallBtn;
	public Button wallExtenderBtn;
	public GameObject gameTapArea;

	public GameObject wall;
	public GameObject ballprefab;
	public GameObject paddleObj;
	public Camera cam;

	// Use this for initialization
	public static GameController _instance;
	void Start () {
		print(Screen.width +":"+ Screen.height);
		string reso = Screen.width.ToString () + "x" + Screen.height.ToString ();
			if(reso == "1080x1920"){
				cam.orthographicSize = 5.37f;
			}
		_instance = this;
		scorePanel_scoretxt.text = PlayerPrefs.GetInt ("bestscore").ToString ();
		//upperRowPanel.transform.position = new Vector3 (0f, -1.72f, 4f);
		//lowerRowPanel.transform.position = new Vector3 (0f, 1.5f, 4f);
	}
	public void click_restart(){
		upperRowPanel.GetComponent<BrickManager> ().Reinit ();
		lowerRowPanel.GetComponent<BrickManager> ().Reinit ();
		scorePanel.SetActive (false);
		scorePanel_scoretxt.text = scoreTxt.text = "0";
		ball1.transform.position = Ball._instance.ballpos;
		Paddle._inst.paddleReInit ();
	}

	public void click_gameTap(){
		click_restart ();
		Time.timeScale = 1;
		ball1.GetComponent<Ball>().gameInit ();
		//ball2.GetComponent<Ball>().gameInit ();
		gameTapArea.SetActive (false);

		//GameController._instance.paddleObj.transform.localPosition = new Vector2 (paddleObj.transform.localPosition.x + 0.25f, paddleObj.transform.localPosition.y);
	}
	public void GameStop(){
		Time.timeScale = 0;
		GameController._instance.scorePanel.SetActive (true);
		GameController._instance.gameTapArea.SetActive (true);
		GameController._instance.ball1.GetComponent<Ball>().hasStarted = false;
		GameController._instance.ball2.GetComponent<Ball>().hasStarted = false;
		Globals.gameStarted = false;
	}
}
