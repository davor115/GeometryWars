// Rory Clark - https://rory.games - 2019
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float m_health = 20f;

    GameObject Player;
    public GameObject explosion;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        m_health = 20;
    }

    public void DamageEnemy(float _damage)
    {
        m_health -= _damage;
        if(m_health <= 0)
        {
            Player.GetComponent<Player_Stats>().AddKillPoints(1); // Everytime we kill an enemy, we add 1 point to our kill count.
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
