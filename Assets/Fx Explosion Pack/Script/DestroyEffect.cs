using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
    float timer = 1.5f;
	void Update ()
	{

		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
		   Destroy(transform.gameObject);

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.transform.gameObject);
        }
	
	}
}
