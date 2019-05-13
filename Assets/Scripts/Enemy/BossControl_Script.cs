using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl_Script : MonoBehaviour
{

    GameObject Player;
    public GameObject[] EnemySpawner;

    public GameObject Level0Boss;

    bool SpawnOnce = false;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");

    }

    // Update is called once per frame
    void Update()
    {
        CheckLevelComplete();
    }

    void CheckLevelComplete()
    {
        if (Player != null)
        {
            if (Player.GetComponent<Player_Stats>()._permanent_kills >= 40 && SpawnOnce == false) // If the player killed a total of 40 enemies...
            {
                foreach (GameObject _spawner in EnemySpawner)
                {
                    _spawner.GetComponent<EnemySpawner>().enabled = false; // Disable all the enemies spawners
                }
                SpawnOnce = true;

                // Spawn the BOSS
                 GameObject Boss0 = Instantiate(Level0Boss, GameObject.Find("Spawn_Boss").transform.localPosition, GameObject.Find("Spawn_Boss").transform.rotation);

            }
        }
    }

}
