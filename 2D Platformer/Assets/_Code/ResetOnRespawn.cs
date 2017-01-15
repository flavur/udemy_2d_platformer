using UnityEngine;
using System.Collections;

public class ResetOnRespawn : MonoBehaviour {

	private Vector3 startPosition;
	private Quaternion startRotation;
	private Vector3 startLocalScale;
	private Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
		startLocalScale = transform.localScale;

		if (GetComponent<Rigidbody2D>() != null)
		{
			myRigidbody = GetComponent<Rigidbody2D>();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Reset is called when the user hits the Reset button in the Inspector's
	/// context menu or when adding the component the first time.
	/// </summary>
	void Reset()
	{
		transform.position = startPosition;
		transform.rotation = startRotation;
		transform.localScale = startLocalScale;
		if (myRigidbody!=null)
		{
			myRigidbody.velocity = Vector3.zero;
		}
	}
}
