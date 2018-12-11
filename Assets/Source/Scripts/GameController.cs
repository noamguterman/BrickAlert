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


	// Use this for initialization
	public static GameController _instance;
	void Start () {
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
}
