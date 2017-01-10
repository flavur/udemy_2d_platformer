using UnityEngine;
using System.Collections;
using UnityEngine.UI; //only needed when using UI elements

public class LevelManager : MonoBehaviour {

	public float waitToRespawn; //sets how long the wait time for the player respawn should be
	public PlayerController thePlayer; //grabs the player GameObject
	public GameObject deathSplosion; //holds the prefab for the death explosion
	public int gemCount; //keeps track of the amount of gems the player has collected

	//UI elements
	public Text gemText; // Gem text display element
	//Player health UI elements
	public Image playerHealth1;
	public Image playerHealth2;
	public Image playerHealth3;
	public Sprite aliveSprite;
	public Sprite deadSprite;

	public int maxHealth;
	public int healthCount; //keeps track of how much health we have in the game

	private bool checkRespawn;


	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		
		//used to display the gemCount in the UI
		gemText.text = "Gems: "+ gemCount;

		healthCount = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		//Checks if playerhealth is < or = to 0 and kills the player if it that statement is true
		if (healthCount<=0 && !checkRespawn)
		{
			Respawn();
			checkRespawn = true;
		}
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

		//reset playerHealth
		healthCount = maxHealth;
		checkRespawn = false;
		updateHeartMeter(); //update the player lives UI
		
		//Respawns the player to the respawnPosition
		thePlayer.transform.position = thePlayer.respawnPosition;
		//reactivates the player in the scene
		thePlayer.gameObject.SetActive(true);
	}

	//keeps track of how many coins are added
	public void addGems(int gemsToAdd){
		//gemCount + gemsToAdd
		gemCount+=gemsToAdd;
		//debug log for displaying amount of gems in the console
		Debug.Log(gemCount);
		//used to display the gemCount in the UI
		gemText.text = "Gems: "+ gemCount;
	}

	//Function to determine how much health the player will lose
	public void HurtPlayer(int damageToTake){
		healthCount-=damageToTake;
		updateHeartMeter();
	}

	//Updates player health UI
	public void updateHeartMeter()
	{
		switch(healthCount)
		{
			case 3: 
				playerHealth1.sprite = aliveSprite;
				playerHealth2.sprite = aliveSprite;
				playerHealth3.sprite = aliveSprite;
				return;
			case 2:
				playerHealth1.sprite = aliveSprite;
				playerHealth2.sprite = aliveSprite;
				playerHealth3.sprite = deadSprite;
				return;
			case 1:
				playerHealth1.sprite = aliveSprite;
				playerHealth2.sprite = deadSprite;
				playerHealth3.sprite = deadSprite;
				return;
			case 0:
				playerHealth1.sprite = deadSprite;
				playerHealth2.sprite = deadSprite;
				playerHealth3.sprite = deadSprite;
				return;
			default: 
				playerHealth1.sprite = deadSprite;
				playerHealth2.sprite = deadSprite;
				playerHealth3.sprite = deadSprite;
				return;
		}
	}
}
