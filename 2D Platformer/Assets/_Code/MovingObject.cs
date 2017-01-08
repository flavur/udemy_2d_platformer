using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	//What is needed for this script
	//what object we're Moving
	//when should it start/end Moving
	//how fast should the object move

	public GameObject objectToMove;
	public Transform startPoint;
	public Transform endPoint;

	public float moveSpeed;

	private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
		//set current target on start
		currentTarget = endPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		//move towards currentTarget
		objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position,currentTarget,moveSpeed*Time.deltaTime);
		//letting the platform know that it needs to move to the other direction
		if (objectToMove.transform.position == endPoint.position)
		{
			//set startpoint as the currentTarget
			currentTarget = startPoint.position;
		}
		if (objectToMove.transform.position == startPoint.position)
		{
			//set endpoint as the currentTarget
			currentTarget = endPoint.position;
		}
	}
}
