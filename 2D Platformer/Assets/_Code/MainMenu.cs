using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string firstLevel;
    public string levelSelect;
    public string[] levelNames;
    public int startingLives;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Continue()
    {
        SceneManager.LoadScene(levelSelect);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(firstLevel);
        for (int i = 0; i < levelNames.Length; i++)
        {
            PlayerPrefs.SetInt(levelNames[i], 0);
        }
        PlayerPrefs.SetInt("GemCount", 0);
        PlayerPrefs.SetInt("PlayerLives", startingLives);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
