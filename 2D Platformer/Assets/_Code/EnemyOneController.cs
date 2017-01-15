using UnityEngine;
using System.Collections;

public class EnemyOneController : MonoBehaviour {

	public float moveSpeed; //movement speed for this enemy
	private bool canMove; //determines whether or not the enemy can move
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove)
		{
			myRigidbody.velocity = new Vector3(-moveSpeed,myRigidbody.velocity.y,0f);
		}
	}

	/// <summary>
	/// OnBecameVisible is called when the renderer became visible by any camera.
	/// </summary>
	void OnBecameVisible()
	{
		canMove = true;
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "KillPlane")
		{
			//Destroy(gameObject);
			gameObject.SetActive(false);
		}
	}

	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	void OnEnable()
	{
		canMove = false;
	}
}
