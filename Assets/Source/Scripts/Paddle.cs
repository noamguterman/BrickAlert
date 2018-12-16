using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX, maxX;
	public Vector3 paddlePos;

	private Ball ball;
	public static Paddle _inst;
	void Start () {
		_inst = this;
		paddlePos = gameObject.transform.position;
		ball = GameObject.FindObjectOfType<Ball>();
	}
	//void OnTriggerEnter2D (Collider2D col) {
		//Debug.Log ("--test2-->>" + col.gameObject.name);
		//GameController._instance.GameStop ();
		//AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
	//}
	// Update is called once per frame

	void Update () {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
	void Mousemove(){
		Debug.Log ("move.......");
	}
	void MoveWithMouse () {
		if (Globals.gameStarted) {
			var mousePos = Input.mousePosition; 
			var wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10)); 
			if (wantedPos.x > 6.69f && wantedPos.x < 9.32f) {
				transform.position = new Vector3 (wantedPos.x, paddlePos.y, 0); 
			}
			/*Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
			float mousePosInBlocks = Input.mousePosition.x / Screen.width * 10;
			if (Mathf.Clamp (mousePosInBlocks, minX, maxX) > 6.20f && Mathf.Clamp (mousePosInBlocks, minX, maxX) < 9.6f) {
				paddlePos.x = Mathf.Clamp (mousePosInBlocks, minX, maxX);
				this.transform.position = paddlePos;
			}*/
		}
	}
	//======================================arun ================================
	public Vector3 incrSize = new Vector3(1.5f,0,0);
	public void incrSize_click()
	{
		Debug.Log ("-----incrSize_click-----");
		transform.localScale += incrSize;
		Invoke ("initScale", 5f);
	}
	void initScale(){
		transform.localScale = new Vector3(.8f, .8f,1f);
	}
	public void paddleReInit(){
		gameObject.transform.position = paddlePos;
	}
	/*
	Vector3 screenPoint;
	Vector3 offset;
	void OnMouseDown()
	{
		Debug.Log ("OnMouseDown");
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset =  transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,screenPoint.z));
	}

	void OnMouseDrag()
	{
		Debug.Log ("OnMouseDrag");
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = new Vector2(curPosition.x,5.821f);
	}*/

}
