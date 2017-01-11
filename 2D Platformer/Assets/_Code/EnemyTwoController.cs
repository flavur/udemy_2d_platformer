using UnityEngine;
using System.Collections;

public class EnemyTwoController : MonoBehaviour {
	public Transform leftPoint;
	public Transform rightPoint;
	public float moveSpeed;
	public bool movingRight;

	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//which direction is the enemy moving towards
		if (movingRight && transform.position.x > rightPoint.position.x)
		{
			movingRight = false;
		}
		if (!movingRight && transform.position.x < leftPoint.position.x)
		{
			movingRight = true;
		}

		//Once we know which direction the enemy is moving then
		//if player is moving right then move enemy to the right
		if (movingRight)
		{
			myRigidbody.velocity = new Vector3(moveSpeed,myRigidbody.velocity.y,0f);
		}
		//if enemy is not moving to the right then move enemy to the left
		else
		{
			myRigidbody.velocity = new Vector3(-moveSpeed,myRigidbody.velocity.y,0f);
		}
	}
}
