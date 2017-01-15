using UnityEngine;
using System.Collections;

public class GemItem : MonoBehaviour {

	private LevelManager theLevelManager;

	public int gemValue;

	// Use this for initialization
	void Start () {
		theLevelManager = FindObjectOfType<LevelManager>();
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
			//Destroy(gameObject);
			gameObject.SetActive(false);
			theLevelManager.addGems(gemValue);
		}
	}
}
