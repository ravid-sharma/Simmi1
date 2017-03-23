using UnityEngine;
using System.Collections;
public class Lose : MonoBehaviour {
	private Ball ball;
	private GameManager gameManager;
	public GameObject[] players;
	public GameObject[] extras;
	IEnumerator Pause() {
		//print("Before Waiting 2 seconds");
		//Switch GameManager State
		gameManager = GameObject.FindObjectOfType<GameManager>();
		gameManager.SwitchState (GameState.Failed);
		//enable the restart and main menu buttons
		gameManager.EnableButtons();
		yield return new WaitForSeconds(2);
		//Find the ball and reset game start
		//ball = GameObject.FindObjectOfType<Ball>();
		//ball.gameStarted = false;
		//Reload level
		//Application.LoadLevel(Application.loadedLevel);
		//print("After Waiting 2 Seconds");
	}
	void OnTriggerEnter2D (Collider2D trigger){
		if (trigger.name == "Ball") {
			//print ("Lost Triggered!");
			//Wait before restarting level
			StartCoroutine (Pause ());
		}
	}
}