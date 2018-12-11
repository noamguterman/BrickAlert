using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {
	float sppedBrick = 2f;
	public GameObject brickRow;
	Vector3 incrTemp = new Vector3(0,0.5f,0);
	public Vector3 temp;

	GameObject obj;
	Vector2 xy;
	bool isGenarate = true;
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
		_instance = this;
		//PlayerPrefs.DeleteAll ();
		initPos = gameObject.transform.position;
		obj = Instantiate (brickRow);
		obj.SetActive (true);
		obj.transform.SetParent (gameObject.transform);
		xy = new Vector2 (0, obj.transform.position.y);
		obj.transform.localPosition = xy;
		temp = obj.transform.localPosition;
		for(int ii = 0; ii < 2; ii++){
			rowSpawn();
		}
	}

	// Update is called once per frame
	void Update () {
		if (isGenarate == false || Globals.isClockStarted || !Globals.gameStarted) {
			return;
		}
		if (direction == fromDirection.UpperDirecter) { 
			transform.Translate (Vector3.up * Time.deltaTime * sppedBrick);
		} else {
			transform.Translate (Vector3.down * Time.deltaTime * sppedBrick);
		}

		rowSpawn ();
		isGenarate = false;
		insertRow ();
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
	void insertRow(){
		CancelInvoke ("genarateRow");
		Invoke ("genarateRow", 1f);
	}
	void genarateRow(){
		isGenarate = true;
	}
	public void Reinit(){
		foreach (Transform child in transform)
		{
			Destroy(child.gameObject);
		}
		//Time.timeScale = 1;
		Globals.points = 0;
		gameObject.transform.position = initPos;
		obj = Instantiate (brickRow);
		obj.SetActive (true);
		obj.transform.SetParent (gameObject.transform);
		xy = new Vector2 (0, obj.transform.position.y);
		obj.transform.localPosition = xy;
		temp = obj.transform.localPosition;
		for(int ii = 0; ii < 2; ii++){
			rowSpawn();
		}

	}
}
