using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	private Paddle paddle;
	public bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Vector2 ballSpeed = new Vector2 (1f, 6f);
	public static Ball _instance;
	public Vector3 ballpos;
	// Use this for initialization
	void Start () {
		_instance = this;
		ballpos = gameObject.transform.position;
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (!hasStarted) {
			// Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// Wait for a mouse press to launch.
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball");
				Globals.gameStarted = true;
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = ballSpeed;
			}
		}*/
	}
	public void gameInit(){
		this.transform.position = paddle.transform.position + paddleToBallVector;
		print ("Mouse clicked, launch ball");
		Globals.gameStarted = true;
		hasStarted = true;
		this.GetComponent<Rigidbody2D>().velocity = ballSpeed;
	}
	public void onInitialStart(){
		hasStarted = true;
		this.GetComponent<Rigidbody2D>().velocity = ballSpeed;
		Invoke ("destroyMyself", 5f);
	}
	void OnCollisionEnter2D (Collision2D collision) {
		// Ball does not trigger sound when brick is destoyed.
		// Not 100% sure why, possibly because brick isn't there.
		if (collision.gameObject.tag == "Ball")
			return;
		
		Vector2 tweak = new Vector2 (Random.Range(0.1f, 0.2f), Random.Range(0.1f, 0.2f));
		
		if (hasStarted) {	
			///GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
	void destroyMyself(){
		Destroy (gameObject);
	}

}
