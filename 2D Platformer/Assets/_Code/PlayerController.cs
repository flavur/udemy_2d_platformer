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
	public bool isGrounded; //use to check if the player is grounded
	public Vector3 respawnPosition;
	public LevelManager theLevelManager;
	public GameObject stompBox;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>(); //grabs the RigidBody component from the player
		myAnim = GetComponent<Animator>(); //grabs the animation component from the player
		respawnPosition = transform.position; //set respawn position to be the initial position of the player
		theLevelManager = FindObjectOfType<LevelManager>(); //grabs the LevelManager script
	}
	
	// Update is called once per frame
	void Update () {

		// Boolean variable that checks whether the player is on the ground or not
		isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

		// Move the player to the right
		if (Input.GetAxisRaw("Horizontal") > 0f){
			myRigidBody.velocity = new Vector3(moveSpeed,myRigidBody.velocity.y,0f); 
			transform.localScale = new Vector3(1f,1f,1f);
			}
		// Move the player to the left
		if (Input.GetAxisRaw("Horizontal") < 0f){
			myRigidBody.velocity = new Vector3(-moveSpeed,myRigidBody.velocity.y,0f); 
			transform.localScale = new Vector3(-1f,1f,1f);
			}
		// Player shouldn't be moving
		if (Input.GetAxisRaw("Horizontal") == 0f){
			myRigidBody.velocity = new Vector3(0f,myRigidBody.velocity.y,0f);
			}
		// Make the player jump (as long as the player is on the ground)
		if (Input.GetButtonDown("Jump") && isGrounded){
			myRigidBody.velocity = new Vector3(myRigidBody.velocity.x,jumpSpeed,0f);
			}

		//Player Animator values
		myAnim.SetFloat("Speed",Mathf.Abs(myRigidBody.velocity.x));
		myAnim.SetBool("Ground",isGrounded);

		//if the player's direction is going down then set the stompBox active
		if (myRigidBody.velocity.y < 0)
		{
			stompBox.SetActive(true);
		}
		//if the players direction is not going down then deactivate the stompBox
		else
		{
			stompBox.SetActive(false);
		}
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
			// gameObject.SetActive(false);
			//transform.position = respawnPosition;
			theLevelManager.Respawn();
		}
		if (other.tag == "Checkpoint")
		{
			respawnPosition = other.transform.position;
		}
	}

	/// <summary>
	/// Sent when an incoming collider makes contact with this object's
	/// collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionEnter2D(Collision2D other)
	{
		//player touches a gameObject with a tag of MovingPlatform then make the player a child of the platform
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = other.transform;
		}
	}

	/// <summary>
	/// Sent when a collider on another object stops touching this
	/// object's collider (2D physics only).
	/// </summary>
	/// <param name="other">The Collision2D data associated with this collision.</param>
	void OnCollisionExit2D(Collision2D other)
	{
		//player is not touching a gameObject with a tag of MovingPlatform then the player is no longer a child of the platform
		if (other.gameObject.tag == "MovingPlatform")
		{
			transform.parent = null;
		}
	}
}
