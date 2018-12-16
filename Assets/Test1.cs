using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("-test1--->>" + col.gameObject.name);
		//AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);


	}
}
