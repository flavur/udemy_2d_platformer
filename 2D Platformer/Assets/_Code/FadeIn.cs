using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    // float that controls the fadein time
    public float fadeTime;
    //private variable that holds the blackScreen image
    private Image blackScreen;


    // Use this for initialization
    void Start()
    {
        blackScreen = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        blackScreen.CrossFadeAlpha(0, fadeTime, false);
        // if the alpha of the blackScreen is 0 meaning that the game is visible then deactivate the script
        if (blackScreen.color.a == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
