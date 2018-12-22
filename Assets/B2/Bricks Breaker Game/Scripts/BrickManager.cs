using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {
	float sppedBrick = 0.07f;
	public GameObject brickRow;
	Vector3 incrTemp = new Vector3(0,0.35f,0);
	public Vector3 temp;
	float rowGenarateInterval = 3f;
	float rowMoveInterval = .02f;
	GameObject obj;
	Vector2 xy;
	bool isGenarate = true;
	bool isRowMove = true;
	// Use this for initialization
	public System.Enum enumerator;
	private Vector3 initPos;
	public static BrickManager _instance;
	public enum fromDirection {
		UpperDirecter,
		LowerDirecter,
	};
	public fromDirection direction;
	void Start () {
		CancelInvoke ("genarateRow");
		_instance = this;
		//PlayerPrefs.DeleteAll ();
		initPos = gameObject.transform.localPosition;
		obj = Instantiate (brickRow);
		obj.SetActive (true);
		obj.transform.SetParent (gameObject.transform);
		xy = new Vector2 (0, obj.transform.position.y);
		obj.transform.localPosition = xy;
		temp = obj.transform.localPosition;
		for(int ii = 0; ii < 10; ii++){
			rowSpawn();
		}
	}

	// Update is called once per frame
	void Update () {
		if (isRowMove == false || Globals.isClockStarted || !Globals.gameStarted) {
			return;
		}
		isRowMove = false;
		if (direction == fromDirection.UpperDirecter) { 
			transform.Translate (Vector3.up * Time.deltaTime * sppedBrick);
		} else {
			transform.Translate (Vector3.down * Time.deltaTime * sppedBrick);
		}
		RowMoveFlag ();


		if (isGenarate == false || Globals.isClockStarted || !Globals.gameStarted) {
			return;
		}
		rowSpawn ();
		isGenarate = false;
		insertRowFlag ();
	}
	void rowSpawn(){
		//Debug.Log ("--------------->>>");
		//Debug.Log (isGenarate);
		if (direction == fromDirection.UpperDirecter) { 
			obj.transform.localPosition -= incrTemp;
		} else {
			obj.transform.localPosition += incrTemp;
		}
		temp = obj.transform.localPosition;
		//Debug.Log (temp);
		obj = Instantiate (brickRow, temp, brickRow.transform.rotation);
		obj.SetActive (true);
		obj.transform.SetParent (gameObject.transform);
		xy = new Vector2 (0, obj.transform.position.y);
		obj.transform.localPosition = xy;
	}
	void RowMoveFlag(){
		CancelInvoke ("RowMove");
		Invoke ("RowMove",rowMoveInterval);
	}
	void RowMove(){
		isRowMove = true;
	}
	void insertRowFlag(){
		CancelInvoke ("genarateRow");
		Invoke ("genarateRow",rowGenarateInterval);
	}
	void genarateRow(){
		isGenarate = true;
	}
	public void Reinit(){
		isGenarate = true;
		isRowMove = true;
		CancelInvoke ("genarateRow");
		CancelInvoke ("RowMove");
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
		//Time.timeScale = 1;
		Globals.points = 0;
		Debug.Log (">>>>>>>?" + initPos);
		gameObject.transform.localPosition = initPos;
		obj = Instantiate (brickRow);
		obj.SetActive (true);
		obj.transform.SetParent (gameObject.transform);
		xy = new Vector2 (0, obj.transform.position.y);
		obj.transform.localPosition = xy;
		temp = obj.transform.localPosition;
		for(int ii = 0; ii < 10; ii++){
			rowSpawn();
		}
	}
	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("---->>" + col.gameObject.name);

	}
}
