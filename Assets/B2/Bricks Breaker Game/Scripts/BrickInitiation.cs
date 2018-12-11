using UnityEngine;
using System.Collections;

public class BrickInitiation : MonoBehaviour {

	public Transform level1;
	public Transform level2;
	public Transform level3;
	// Use this for initialization
	void Start () {
		//level_3 ();
		//Invoke("level_"+PlayerPrefs.GetInt("level"),0);
	}

	void level_1()
	{
		Instantiate(level1,new Vector3(0f, 0f, 0), Quaternion.identity);
		/*Instantiate(level1,new Vector3(0f, 0f, 0), Quaternion.identity);
		PlayerPrefs.SetInt("level", 2);
		PlayerPrefs.Save();*/
	}

	void level_2()
	{
		Instantiate(level2,new Vector3(0f, 0f, 0), Quaternion.identity);
		PlayerPrefs.SetInt("level", 1);
		PlayerPrefs.Save();
	}
	void level_3()
	{
		Instantiate(level3);
		/*Instantiate(level1,new Vector3(0f, 0f, 0), Quaternion.identity);
		PlayerPrefs.SetInt("level", 2);
		PlayerPrefs.Save();*/
	}


}
