using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public string levelSelect;
    public string mainMenu;
	public GameObject thePauseScreen;

	private LevelManager theLevelManager;

    // Use this for initialization
    void Start()
    {
		theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.P))
		{
			thePauseScreen.SetActive(true);
		}
    }

    public void ResumeGame()
    {
		thePauseScreen.SetActive(false);
    }

    public void LevelSelect()
    {
		PlayerPrefs.SetInt("PlayerLives",theLevelManager.currentLives);
		PlayerPrefs.SetInt("GemCount",theLevelManager.gemCount);

		SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMain()
    {
		SceneManager.LoadScene(mainMenu);
    }
}
