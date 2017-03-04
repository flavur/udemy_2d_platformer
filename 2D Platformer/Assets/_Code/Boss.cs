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
	private float dropCount;
	private float platformCount;

    // Use this for initialization
    void Start()
    {
		dropCount = timeBetweenDrops;
		platformCount = waitForPlatforms;
    }

    // Update is called once per frame
    void Update()
    {
		if (bossActive)
		{
			if (dropCount > 0)
			{
				//setting up the countdown
				dropCount -= Time.deltaTime;
			}
			else
			{
				dropSawSpawnPoint.position = new Vector3(Random.Range(leftPoint.position.x,rightPoint.position.x),dropSawSpawnPoint.position.y,dropSawSpawnPoint.position.z);
				Instantiate(dropSaw,dropSawSpawnPoint.position, dropSawSpawnPoint.rotation);
				dropCount = timeBetweenDrops;
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
