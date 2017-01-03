using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//Private variables
	private Rigidbody2D myRigidBody; //Player RigidBody
	private Animator myAnim; //Holds player animations

	//Public variables
	public float moveSpeed = 1f; //player move speed
	public float jumpSpeed = 2f; //Player jump speed

	// Variables used to check whether the player is touching the ground
	public Transform groundCheck; //Position in space
	public float groundCheckRadius; //Radius of the groundCheck Position
	public LayerMask whatIsGround;
	public bool isGrounded;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		// Boolean variable that checks whether the player is on the ground or not
		isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

		// Move the player to the right
		if (Input.GetAxisRaw("Horizontal") > 0f){myRigidBody.velocity = new Vector3(moveSpeed,myRigidBody.velocity.y,0f);}
		// Move the player to the left
		if (Input.GetAxisRaw("Horizontal") < 0f){myRigidBody.velocity = new Vector3(-moveSpeed,myRigidBody.velocity.y,0f);}
		// Player shouldn't be moving
		if (Input.GetAxisRaw("Horizontal") == 0f){myRigidBody.velocity = new Vector3(0f,myRigidBody.velocity.y,0f);}
		// Make the player jump (as long as the player is on the ground)
		if (Input.GetButtonDown("Jump") && isGrounded){myRigidBody.velocity = new Vector3(myRigidBody.velocity.x,jumpSpeed,0f);}

		//Player Animator values
		myAnim.SetFloat("Speed",Mathf.Abs(myRigidBody.velocity.x));
		myAnim.SetBool("Ground",isGrounded);
	}
}
