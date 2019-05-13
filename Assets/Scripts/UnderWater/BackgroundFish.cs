using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFish : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
    IEnumerator Check()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position); // get the position of the fish and transform it to view port point.
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // We check if the fish is in the screen.
        if (!onScreen) // If the fish is not on the screen..
        {
            Destroy(this.gameObject); // Destroy it.
        }
        yield return new WaitForSeconds(5.0f); // Run this Co routine every 5 seconds..
    }

	// Update is called once per frame
	void Update ()
    {
        transform.Translate(-transform.forward * 20.0f *Time.deltaTime);
        if (transform.position.x < 0) // Start checking if the fish is inside the screen after they reach half of the screen. We do this to avoid making them dissapear as soon as they instantiate.
        {
            StartCoroutine(Check());
        }
	}
}
