using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	public Sprite[] hitSprites;
	public AudioClip crackSound;
	public static int breakableCount = 0;
	public GameObject particles;

	// Use this for initialization
	void Start () {

		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint (crackSound, transform.position);
		if (isBreakable)
			HandleHit ();
	}

	void HandleHit(){
		timesHit++;
		SetParticles ();

		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			print ("breakableCount= " + breakableCount);
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		}
		else
			LoadSprites ();
	}

	void SetParticles(){
		Vector3 particlePosition = this.transform.position;
		particlePosition.z -= 1;
		var color = this.GetComponent<SpriteRenderer> ().color;

		GameObject puff = Instantiate (particles, particlePosition, Quaternion.identity) as GameObject;
		puff.GetComponent<Renderer> ().material.color = color;
	}

	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites[spriteIndex];
	}
	//TODO remove this method once the mechanics is complete
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
