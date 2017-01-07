using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

	public float lifeTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//taking a fraction of the lifetime away until lifetime == 0
		lifeTime = lifeTime - Time.deltaTime;
		//if lifeTime is less than or equal to zero then Destroy the gameObject this script is attached to
		if (lifeTime <= 0f)
		{
			Destroy(gameObject);
		}
	}
}
