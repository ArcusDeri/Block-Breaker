using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;


	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted)
			this.transform.position = paddle.transform.position + paddleToBallVector;	
		if (Input.GetMouseButtonDown (0)) {
			hasStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Vector2 compensateVector = new Vector2(Random.Range(-0.5f, 0.3f),Random.Range(0f,0.3f));
		print (compensateVector);
		AudioSource audioClip = GetComponent<AudioSource>();
		Rigidbody2D rigidBody2D = GetComponent<Rigidbody2D> ();
		if (hasStarted) {
			audioClip.Play ();
			rigidBody2D.velocity += compensateVector;
		}
	}
}
