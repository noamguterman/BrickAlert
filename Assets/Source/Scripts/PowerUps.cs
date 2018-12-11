using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour {
	public Slider sld;
	public Button btn;
	public float totTime;
	float count = 0;
	// Use this for initialization
	void Start () {
		//btn.enabled = false;
		InitSlider ();
	}
	void InitSlider(){
		//////Invoke ("SliderIncr", 1f);
	}

	void SliderIncr(){
		
		if (count < totTime) {
			count++;
			sld.value = 100 / totTime * count;
			//Debug.Log ("SliderIncr >>" + (100 / totTime));
			Invoke ("SliderIncr", 1f);
		} else {
			btn.enabled = true;
			CancelInvoke ("SliderIncr");
		}
	}
	void SliderDecre(){
	}
	

}
