// Rory Clark - https://rory.games - 2019
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float m_health = 20f;

    GameObject Player;

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
            Player.GetComponent<Player_Stats>().AddKillPoints(1);
            Destroy(gameObject);
        }
    }
}
