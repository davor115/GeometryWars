
using UnityEngine;

public class Boss_BulletVelocity : MonoBehaviour
{
    public Vector3 _position;
    Rigidbody m_rigidbody;
    GameObject Player;
    [SerializeField]
    float m_maxVelocity = 100f;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _position = transform.position;
       
        gameObject.transform.Translate(new Vector3(0, 0, 1) * 50 * Time.deltaTime);
       
        // Destroy the object if it's gone to far
        // Much easier than checking if it's directly off the screen, however has to be manually defined and will not work effectively on different aspect ratios
        if (_position.x <= -4.0f)
        {
            Destroy(gameObject);
        }
    }

    

}