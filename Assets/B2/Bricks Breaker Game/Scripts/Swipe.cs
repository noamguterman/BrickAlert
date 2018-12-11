using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {
	public delegate void ClickAction();
	public static event ClickAction OnClicked;

	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	bool startTap = false;

	void Start () {
		
	}
	void Update(){
		init ();
	}
	public void init()
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			Debug.Log ("drag");
			if (startTap == false) {
				startTap = true;
				//save began touch 2d point
				firstPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
			} else {
				
			}
		}
		if (startTap) {
			secondPressPos = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2 (secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			//normalize the 2d vector
			currentSwipe.Normalize ();

			//swipe upwards
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				Debug.Log ("up swipe");
			}
			//swipe down
			if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				Debug.Log ("down swipe");
			}
			//swipe left
			if (currentSwipe.x < 0) {//&&  currentSwipe.y > -0.5f &&  currentSwipe.y < 0.5f
				Debug.Log ("left swipe");
				///Charectar._instance.lefttarm_down ();
				if (GameController._instance.paddleObj.transform.position.x > 5.38f )
					GameController._instance.paddleObj.transform.localPosition = new Vector2 (Input.mousePosition.x, GameController._instance.paddleObj.transform.localPosition.y);

			}
			//swipe right
			if (currentSwipe.x > 0) {//&& currentSwipe.y > -0.5f && currentSwipe.y < 0.5f
				Debug.Log ("right swipe");
				if ( GameController._instance.paddleObj.transform.position.x < 11f)
					GameController._instance.paddleObj.transform.position = new Vector2 (Input.mousePosition.x, GameController._instance.paddleObj.transform.localPosition.y);
				//Charectar._instance.rightarm_down ();
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			startTap = false;

		}
	}

}
