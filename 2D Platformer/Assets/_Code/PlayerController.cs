using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 1f; //player move speed
	public float jumpSpeed = 2f; //Player jump speed
	private Rigidbody2D myRigidBody; //Player RigidBody

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// Move the player to the right
		if (Input.GetAxisRaw("Horizontal") > 0f){myRigidBody.velocity = new Vector3(moveSpeed,myRigidBody.velocity.y,0f);}
		// Move the player to the left
		if (Input.GetAxisRaw("Horizontal") < 0f){myRigidBody.velocity = new Vector3(-moveSpeed,myRigidBody.velocity.y,0f);}
		// Player shouldn't be moving
		if (Input.GetAxisRaw("Horizontal") == 0f){myRigidBody.velocity = new Vector3(0f,myRigidBody.velocity.y,0f);}
		// Make the player jump
		if (Input.GetButtonDown("Jump")){myRigidBody.velocity = new Vector3(myRigidBody.velocity.x,jumpSpeed,0f);}
	}
}
