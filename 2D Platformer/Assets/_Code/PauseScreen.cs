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
    private PlayerController thePlayer;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
			if (Time.timeScale == 0f)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        thePauseScreen.SetActive(true);
        thePlayer.canMove = false;
        theLevelManager.levelMusic.Pause();
    }

    public void ResumeGame()
    {
        thePauseScreen.SetActive(false);
        Time.timeScale = 1;
        thePlayer.canMove = true;
        theLevelManager.levelMusic.Play();
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.currentLives);
        PlayerPrefs.SetInt("GemCount", theLevelManager.gemCount);
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
