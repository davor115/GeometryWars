// Rory Clark - https://rory.games - 2019
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    GameObject BuyMenu;
    bool isActive;
    public bool ShootAutomatically;
    public bool ExtraBullets;
    [SerializeField]
    GameObject m_bulletPrefab = null;

    [SerializeField]
    Transform m_spawnPosition = null;

    [SerializeField]
    Transform m_spawnPosition_2 = null;

    [SerializeField]
    Transform m_spawnPosition_3 = null;

    [SerializeField]
    KeyCode m_fireKey = KeyCode.Space;

    [SerializeField]
    float m_fireRate = 0.25f;
    float m_currentFireTimer = 0f;

    void Awake()
    {
        BuyMenu = GameObject.FindGameObjectWithTag("BuyMenu");
        BuyMenu.SetActive(false);
    }
    void Start()
    {
        ShootAutomatically = false;
        isActive = false;
       
    }

    void Update()
    {
        if (m_currentFireTimer > 0)
        {
            m_currentFireTimer -= Time.deltaTime;
        }

        // GetKeyDown and GetKey will happen at different times
        // GetKeyDown will happen as soon as the user presses the key
        // GetKey will work when it is held
        if ((Input.GetKeyDown(m_fireKey) && m_currentFireTimer <= 0 || Input.GetKey(m_fireKey) && m_currentFireTimer <= 0 && ShootAutomatically))
        {
            m_currentFireTimer = m_fireRate;
            SpawnBullet();
        }
        
        if(Input.GetKeyDown(KeyCode.B))
        {
            isActive = !isActive;
            BuyMenu.SetActive(isActive);
        }
    }

    void SpawnBullet()
    {
        GameObject go = Instantiate(m_bulletPrefab, m_spawnPosition.position, m_spawnPosition.rotation);
        //go.transform.position = m_spawnPosition.position;
        if(ExtraBullets)
        {
            SpawnExtraBullets();
        }

    }

    void SpawnExtraBullets()
    {

        GameObject go1 = Instantiate(m_bulletPrefab, m_spawnPosition_2.position, m_spawnPosition_2.rotation);
        //go1.transform.position = m_spawnPosition_2.position;
        //go1.transform.rotation = m_spawnPosition_2.transform.rotation;

        GameObject go2 = Instantiate(m_bulletPrefab, m_spawnPosition_3.position, m_spawnPosition_3.rotation);
        //go2.transform.position = m_spawnPosition_3.position;
        //go2.transform.rotation = m_spawnPosition_3.transform.rotation;
    }

}
