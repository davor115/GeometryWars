using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitVideo : MonoBehaviour {

    float timer;
    GameObject _canvas;
	// Use this for initialization
	void Start ()
    {
        timer = 20.0f;
        _canvas = GameObject.Find("Canvas");
        _canvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Wait some time before activating the menu to go back to main menu.
		if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            _canvas.SetActive(true);
        }
	}
}
