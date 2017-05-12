using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	private float mouseXBlocks;
	private Ball ball;

	public bool autoPlay = false;

	// Use this for initialization
	void Start () {
			ball = FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MouseControl ();
		} else {
			AutoControl ();
		}
	}

	private void MouseControl(){
		Vector3 paddlePos = new Vector3 (0.5f, 0.5f, 0f);
		mouseXBlocks = (float) Input.mousePosition.x / Screen.width * 16;

		paddlePos.x = Mathf.Clamp(mouseXBlocks, 1.2f, 14.7f);
		this.transform.position = paddlePos;
	}
	private void AutoControl(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPosition = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPosition.x,0.5f,15.5f);
		this.transform.position = paddlePos;
	}
}
