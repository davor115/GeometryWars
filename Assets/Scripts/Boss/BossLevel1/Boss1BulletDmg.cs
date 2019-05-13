using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1BulletDmg : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")) // If the bullet hits a gameObject of tag player...
        {
            Debug.Log("Hit the player. Deal damage.");
            other.gameObject.GetComponent<Player_Stats>().TakeDamage(5); // Damage the player..
            Destroy(this.gameObject);
        }
        
    }

}
