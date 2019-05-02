using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuyMenu : MonoBehaviour {

    GameObject Player;
    public GameObject Bullet;
    float effectCooldown1;
    public float effectCooldown2;
    public bool isActive; // If bullet damage is active.
	// Use this for initialization
	void Start () {
        
        Player = GameObject.FindGameObjectWithTag("Player");
        effectCooldown1 = 15.0f;
        effectCooldown2 = 10.0f;
        isActive = false;
	}
	
	// Update is called once per frame
	void Update ()
    {     

        if (Player != null)
        {
            if (Player.GetComponent<PlayerShoot>().ShootAutomatically == true)
            {
                if (effectCooldown1 >= 0)
                {
                    effectCooldown1 -= Time.deltaTime;
                }
                else
                {
                    Player.GetComponent<PlayerShoot>().ShootAutomatically = false;
                    effectCooldown1 = 15.0f;
                }             
            }          
        }
        if (isActive) // If we chose to upgrade the bullet damage.
        {
            if (effectCooldown2 >= 0)
            {
                effectCooldown2 -= Time.deltaTime;
            }
            else
            {
                isActive = false;
                Bullet.GetComponent<BulletDamage>().m_damage /= 2;
                effectCooldown2 = 10.0f;
            }
        }     
    }

    public void Buy_AutomaticShooting()
    {
        if (Player.GetComponent<Player_Stats>().GetKills() >= 20)
        {
            GameObject.FindGameObjectWithTag("BuyMenu").SetActive(false);
            Player.GetComponent<Player_Stats>().RemoveKillPoints(20);
            Player.GetComponent<PlayerShoot>().ShootAutomatically = true;
        }
    }

    public void ImproveBulletDamage()
    {
        if(Player.GetComponent<Player_Stats>().GetKills() >= 15 )
        {
            GameObject.Find("Canvas_WorldSpace").SetActive(false);
            Player.GetComponent<Player_Stats>().RemoveKillPoints(15);
            Bullet.GetComponent<BulletDamage>().m_damage *= 2;
            isActive = true;
        }
    }

}
