using UnityEngine;

public class Player2DExample : MonoBehaviour 
{
    public float moveSpeed = 8f;
    public Joystick joystick;

    private void Update()
    {
        Vector3 moveVector = (Vector3.right * joystick.Horizontal + Vector3.up * joystick.Vertical);

        if (moveVector != Vector3.zero)
        { 
           // transform.rotation = Quaternion.LookRotation(Vector3.forward, moveVector);
			Debug.Log(">???" + transform.position.x);
			if (transform.position.x > 5.38f && transform.position.x < 11f) {
				transform.Translate (moveVector * moveSpeed * Time.deltaTime, Space.World);
			}else if(transform.position.x <= 5.38f){
				transform.position = new Vector2 (5.45f, 5.821f);
			}else if(transform.position.x >= 11f){
				transform.position = new Vector2 (10.9f, 5.821f);
			}
        }
    }
}
