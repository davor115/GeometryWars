// Rory Clark - https://rory.games - 2019
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField]
    public float m_damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        // Damage the enemy if we hit one, destroy ourselves
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.DamageEnemy(m_damage);
            Destroy(gameObject);
        }
        // Since in the second scene I will be using the same bullet "misiles" for both the player and the boss..
        // I will check if he hit a Boss or the Player and remove health from it.
        if(other.gameObject.CompareTag("Boss"))
        {
            if (other.GetComponent<Boss1>() != null)
            {
                other.GetComponent<Boss1>().DamangeBoss(m_damage);
            }
            if(other.GetComponent<Boss2>() != null)
            {
                other.GetComponent<Boss2>().DamangeBoss(m_damage);
            }
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit the player. Deal damage.");
            other.gameObject.GetComponent<Player_Stats>().TakeDamage(5);
            Destroy(this.gameObject);
        }
      

    }
}
