using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {

	public GameObject deathSplosion;

	// Use this for initialization
	void Start () {
	
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
		if (other.tag == "Enemy")
		{
			Destroy(other.gameObject);
			Instantiate(deathSplosion,other.transform.position,other.transform.rotation);
		}
	}
}
