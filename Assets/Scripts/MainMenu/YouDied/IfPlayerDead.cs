using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IfPlayerDead : MonoBehaviour {

    public bool isDead;
    float wait;
	// Use this for initialization
	void Start ()
    {
        wait = 5.5f;

    }
	
	// Update is called once per frame
	void Update ()
    {
		if(isDead)
        {
            if(wait > 0)
            {
                wait -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("mainmenu");
            }
        }

	}
}
