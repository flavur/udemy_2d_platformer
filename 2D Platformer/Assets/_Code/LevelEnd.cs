using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public string levelToLoad;
	public float waitToMove;
	public float waitToLoad;

	private PlayerController thePlayer;
	private CameraController theCamera;
	private LevelManager theLevelManager;
	private bool movePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		theCamera = FindObjectOfType<CameraController>();
		theLevelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (movePlayer)
		{
			thePlayer.myRigidBody.velocity = new Vector3(thePlayer.moveSpeed,thePlayer.myRigidBody.velocity.y,0f);
		}
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			// SceneManager.LoadScene(levelToLoad);
			StartCoroutine("LevelEndCo");
		}
	}
	
	public IEnumerator LevelEndCo()
	{
		// Player should no longer be able to move
		thePlayer.canMove = false;
		// Camera should no longer follow the player
		theCamera.followTarget = false;
		// make the player invincible
		theLevelManager.invincible = true;
		// resets the players movement to zero
		thePlayer.myRigidBody.velocity = Vector3.zero;

		//tells game to wait for a certain amount of time before resuming
		yield return new WaitForSeconds(waitToMove);
		//allows the player to move once the wait time is up
		movePlayer = true;

		yield return new WaitForSeconds(waitToLoad);

		SceneManager.LoadScene(levelToLoad);
	}

}
