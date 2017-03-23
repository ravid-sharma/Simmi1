using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class Paddle : MonoBehaviour {
	public int i=0;
	//Make the AudioClip configurable in the editor
	public AudioClip Sound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Set variable for current position
		Vector3 paddlePos = new Vector3 (8f, this.transform.position.y, 0f);
		//Get mouse position
		float mousePos = Input.mousePosition.x / Screen.width * 10;
		//Set new mouse X position
		paddlePos.x = Mathf.Clamp(mousePos-5.5f, -2.5f, 2.9f);
		//Change paddle to match new X position
		this.transform.position = paddlePos;
	}
	//OnCollisionEnter will only be called when one of the colliders has a rigidbody
	void OnCollisionEnter2D(Collision2D c)
	{
		//Change the sound pitch if a slowdown powerup has been picked up
		//GetComponent<AudioSource>().pitch = Time.timeScale;
		//Play it once for this collision hit
		GetComponent<AudioSource>().PlayOneShot(Sound);
	}
}
