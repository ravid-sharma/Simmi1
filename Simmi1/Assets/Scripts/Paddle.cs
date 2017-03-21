using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public int i=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Set variable for current position
		Vector3 paddlePos = new Vector3 (8f, this.transform.position.y, 0f);
		//Get mouse position
		float mousePos = Input.mousePosition.x / Screen.width * 16;
		//Set new mouse X position
		paddlePos.x = Mathf.Clamp(mousePos-8.5f, -5.5f, 5.5f);
		//Change paddle to match new X position
		this.transform.position = paddlePos;
	}
}
