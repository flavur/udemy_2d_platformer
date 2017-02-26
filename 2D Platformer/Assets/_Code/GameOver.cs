using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public string mainMenu;
    public string levelSelect;

    private LevelManager theLevelManager;

    // Use this for initialization
    void Start()
    {
        theLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Restart()
    {
        PlayerPrefs.SetInt("GemCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect()
    {
        PlayerPrefs.SetInt("GemCount", 0);
        PlayerPrefs.SetInt("PlayerLives", theLevelManager.startingLives);

		SceneManager.LoadScene(levelSelect);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
