using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {

	public Sprite flagClosed; //holds closed checkpoint Sprite
	public Sprite flagOpen; //holds open checkpoint Sprite
	public bool checkpointActive;

	private SpriteRenderer theSpriteRenderer; //grabs the SpriteRenderer of the object that this script is attached to

	// Use this for initialization
	void Start () {
		theSpriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
			theSpriteRenderer.sprite = flagOpen;
			checkpointActive = true;
		}
	}
}
