using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target; //object that the camera is going to be following
	public float followAhead = 5f; //amount of distance that the camera will be ahead of the player
	public float smoothing;
	public float yOffset; // offset to keeps camera above a certain level when following the player

	private Vector3 targetPosition;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Making the camera follow the target object but keep it y and z positioning
		targetPosition = new Vector3(target.transform.position.x,target.transform.position.y+yOffset,transform.position.z);

		//This will move the camera ahead of the player depending on the characters position
		//determine if the player is facing right
		if(target.transform.localScale.x > 0f){
			//where we want the camera to move to
			targetPosition = new Vector3(targetPosition.x+followAhead,targetPosition.y,targetPosition.z);
		}
		if(target.transform.localScale.x < 0f){
			//where we want the camera to move to
			targetPosition = new Vector3(targetPosition.x-followAhead,targetPosition.y,targetPosition.z);
		}

		//Sets the position of the Camera
		// transform.position = targetPosition;
		transform.position = Vector3.Lerp(transform.position,targetPosition,smoothing*Time.deltaTime);
	}
}
