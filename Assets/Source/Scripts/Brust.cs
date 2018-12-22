using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brust : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("destroyFab", 1f);
	}
	void destroyFab(){
		Destroy (gameObject);
	}

}
