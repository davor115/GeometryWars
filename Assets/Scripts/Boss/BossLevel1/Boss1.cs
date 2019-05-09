using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {

    bool turn;
    float waitTime;
    float setTime;
    public GameObject[] shootPos;
    public GameObject Projectile;
	// Use this for initialization
	void Start ()
    {
        turn = false;
        shootPos = GameObject.FindGameObjectsWithTag("ShootPosition");
        setTime = 2.0f;
        waitTime = setTime;

    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        if (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
           // Debug.Log("Wait time: " + waitTime);
        }
        else
        {
            Shoot();
            waitTime = setTime;
        }
	}

    void Move()
    {
        if (transform.localPosition.z < 9 && !turn)
        {
            transform.Translate(new Vector3(1, 0, 0) * 2.0f * Time.deltaTime);
            if (transform.localPosition.z >= 9)
            {
                turn = true;
            }

        }
        else if (turn)
        {
            transform.Translate(new Vector3(-1, 0, 0) * 2.0f * Time.deltaTime);
            if (transform.localPosition.z <= -9)
            {
                turn = false;
            }
        }
    }

    void Shoot()
    {
        for(int i = 0; i < shootPos.Length; i++)
        {
            GameObject projectile = Instantiate(Projectile, shootPos[i].transform.position, shootPos[i].transform.rotation);
            Debug.Log("Fire!");
        }
    }
}
