using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	public float fadeTime;
	private Image blackScreen;


	// Use this for initialization
	void Start () {
		blackScreen = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		blackScreen.CrossFadeAlpha(0,fadeTime,false);

		if (blackScreen.color.a == 0)
		{
			gameObject.SetActive(false);
		}	
	}
}
