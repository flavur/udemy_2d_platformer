using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float waitToRespawn;
	public PlayerController thePlayer;

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
		thePlayer.gameObject.SetActive(false);

		//tells game to wait for a certain amount of time before resuming
		yield return new WaitForSeconds(waitToRespawn);

		thePlayer.transform.position = thePlayer.respawnPosition;
		thePlayer.gameObject.SetActive(true);
	}
}
