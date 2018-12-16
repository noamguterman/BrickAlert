using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {
	public enum TypeOfObj {
		Paddle,
		other,
	};
	public TypeOfObj objtype;
	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		//Debug.Log ("--test2-->>" + collision.gameObject.tag);
		if (objtype == TypeOfObj.Paddle) { 
			if (collision.gameObject.tag == "BreakableGreen" || collision.gameObject.tag == "BreakableRed") {
				//Debug.Log ("--test2-->>" + collision.gameObject.name);
				GameController._instance.GameStop ();
			}
		} else {
			if (collision.gameObject.tag == "BreakableRed") {
				//Debug.Log ("--test2-->>" + collision.gameObject.name);
				GameController._instance.GameStop ();
			}
		}
		//AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
	}
}
