﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Brick : MonoBehaviour {
	public int maxHits;
	public int timesHit;
	private bool BrickIsDestroyed=false;
	//Define the AudioClip and Pitch
	public AudioClip Sound;
	public float PitchStep = 0.05F;
	public float MaxPitch = 1.3F;
	//Make the current pitch value global
	public static float pitch = 1;
	public Animator anim;
	//Falling variables
	public bool FallDown = false;
	[HideInInspector]
	public bool BlockIsDestroyed = false;
	private Vector2 velocity = Vector2.zero;
	// Use this for initialization
	void Start () {
		timesHit = 0;
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (FallDown && velocity != Vector2.zero)
		{
			Vector2 pos = (Vector2)transform.position;
			pos += velocity * Time.deltaTime;
		}
	}
	void OnBecameInvisible()
	{
		BlockIsDestroyed = true;
		Destroy(gameObject);
	}
	private IEnumerator OnCollisionExit2D(Collision2D c)
	{
		if (timesHit == maxHits) {
			//print ("Destroyed on Exit!");
			//print ("Play Woggle!");
			GetComponent<Collider2D> ().enabled = false;
			//Play the Woggle animation
			//GetComponent<Animation> ().Play ();
			//Wait here for the length of the Woggle animation
			yield return new WaitForSeconds (2);
			//Animation Woggle has finished, now decide what to do, falldown or just disappear
			if (FallDown) {
				//print ("Falling!");
				//Falldown to the direction the ball hit it, with a random speed and plus a little downwards "gravity"
				velocity = new Vector2 (0, Random.Range (1, 12.0F) * -1);
			}
			else {
				GetComponent<Renderer>().enabled = false;
			}
			Destroy (gameObject);
		}
		else {
			//print ("Max hits not reached");
		}
	}
	void OnCollisionEnter2D(Collision2D Col){
		timesHit++;
		//print ("Ouch you hit me this many times:"+timesHit);
		//print ("Playing brick sound!");
		//Increase pitch
		//pitch += PitchStep;
		//Limit pitch
		//if (pitch > MaxPitch)
		//	pitch = 1; //Reset pitch to one so it starts over with the lower tone
		//Apply pitch
		//GetComponent<AudioSource>().pitch = pitch;
		//Play it once for this collision hit
		GetComponent<AudioSource>().PlayOneShot(Sound);
		anim.SetBool ("Idle", false);
		anim.SetBool ("Die", true);
		StartCoroutine(OnCollisionExit2D(Col));
	}
}
