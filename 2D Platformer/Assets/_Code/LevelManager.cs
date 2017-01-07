using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float waitToRespawn; //sets how long the wait time for the player respawn should be
	public PlayerController thePlayer; //grabs the player GameObject
	public GameObject deathSplosion; //holds the prefab for the death explosion

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//deactivates the player moves them and then reactivates them
	public void Respawn(){
		StartCoroutine("RespawnCoRoutine");
	}

	public IEnumerator RespawnCoRoutine(){
		//deactive the player object
		thePlayer.gameObject.SetActive(false);

		//display the character death particle effect
		Instantiate(deathSplosion,thePlayer.transform.position,thePlayer.transform.rotation);

		//tells game to wait for a certain amount of time before resuming
		yield return new WaitForSeconds(waitToRespawn);

		thePlayer.transform.position = thePlayer.respawnPosition;
		thePlayer.gameObject.SetActive(true);
	}
}
