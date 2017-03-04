using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public bool bossActive;
    public float timeBetweenDrops;
    public float waitForPlatforms;
    public Transform leftPoint;
    public Transform rightPoint;
    public Transform dropSawSpawnPoint;
    public GameObject dropSaw;
    public GameObject theBoss;
    public bool bossRight;
    public GameObject rightPlatforms;
    public GameObject leftPlatforms;
    public bool takeDamage;
    public int startingHealth;
    public int currentHealth;
    private float dropCount;
    private float platformCount;

    // Use this for initialization
    void Start()
    {
        dropCount = timeBetweenDrops;
        platformCount = waitForPlatforms;

        theBoss.transform.position = rightPoint.position;
        bossRight = true;

        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossActive)
        {
            theBoss.SetActive(true);

            if (dropCount > 0)
            {
                //setting up the countdown
                dropCount -= Time.deltaTime;
            }
            else
            {
                dropSawSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x, rightPoint.position.x), dropSawSpawnPoint.position.y, dropSawSpawnPoint.position.z);
                Instantiate(dropSaw, dropSawSpawnPoint.position, dropSawSpawnPoint.rotation);
                dropCount = timeBetweenDrops;
            }

            //spawning platforms based on the bosses position
            if (bossRight)
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    rightPlatforms.SetActive(true);
                }
            }
            else
            {
                if (platformCount > 0)
                {
                    platformCount -= Time.deltaTime;
                }
                else
                {
                    leftPlatforms.SetActive(true);
                }
            }

            //when the boss takes damage
            if (takeDamage)
            {
                currentHealth -= 1;

				//sets the boss position
				if (bossRight)
				{
					theBoss.transform.position = leftPoint.position;
				}
				else
				{
					theBoss.transform.position = rightPoint.position;
				}

				bossRight = !bossRight;

				rightPlatforms.SetActive(false);
				leftPlatforms.SetActive(false);

				platformCount = waitForPlatforms;

				timeBetweenDrops = timeBetweenDrops/2f;

                takeDamage = false;
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            bossActive = true;
        }
    }
}
