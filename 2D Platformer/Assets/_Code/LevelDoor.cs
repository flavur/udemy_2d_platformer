using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : MonoBehaviour
{

    public string levelToLoad;
    public Sprite doorBottomOpen;
    public Sprite doorTopOpen;
    public Sprite doorBottomClosed;
    public Sprite doorTopClosed;
    public bool unlocked;

    public SpriteRenderer doorTop;
    public SpriteRenderer doorBottom;

    // Use this for initialization
    void Start()
    {

		PlayerPrefs.SetInt("unititled-1",1);

		if (PlayerPrefs.GetInt(levelToLoad)==1)
		{
			unlocked = true;
		}
		else
		{
			unlocked = false;
		}

        if (unlocked)
        {
            doorTop.sprite = doorTopOpen;
            doorBottom.sprite = doorBottomOpen;
        }
        else
        {
            doorTop.sprite = doorTopClosed;
            doorBottom.sprite = doorBottomClosed;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Sent each frame where another object is within a trigger collider
    /// attached to this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Jump") && unlocked)
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}
