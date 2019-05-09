using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl_Script : MonoBehaviour
{

    GameObject Player;
    GameObject EnemySpawner;

    public GameObject Level0Boss;

    bool SpawnOnce = false;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemySpawner = GameObject.Find("EnemySpawner");

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player_Stats>()._permanent_kills >= 40 && SpawnOnce == false)
        {
            EnemySpawner.GetComponent<EnemySpawner>().enabled = false;
            SpawnOnce = true;

            if (Player.GetComponent<Player_Stats>()._currentLevel == 0)
            {
                GameObject Boss0 = Instantiate(Level0Boss, GameObject.Find("Spawn_Boss").transform.localPosition, GameObject.Find("Spawn_Boss").transform.rotation);

            }

        }
    }
}
