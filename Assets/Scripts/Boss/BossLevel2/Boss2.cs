using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss2 : MonoBehaviour
{

    GameObject Explosion_Panel;

    bool deadYet = false;
    float time = 0.0f;
    float nextPeriod = 0.3f;

    public AudioClip bigPewPew;
    public AudioClip deadBoss;

    public float boss_health;
    public Slider Slider_health;
    bool turn;
    float b_moveSpeed;
    float waitTime;
    float setTime;
    public GameObject shootPos;
    public GameObject Misile;

    public GameObject _explosion;

    // The comments used in Boss1 apply here because it is almost using the same code..

    // Use this for initialization
    void Start()
    {
        Explosion_Panel = GameObject.Find("Explosion_Panel");
        b_moveSpeed = 6.0f;
        turn = false;
        shootPos = GameObject.FindGameObjectWithTag("ShootPosition");
        setTime = .5f;
        waitTime = setTime;
        boss_health = 400f;
        Slider_health.maxValue = boss_health;
    }

    // Update is called once per frame
    void Update()
    {
        Slider_health.value = boss_health;
        if (boss_health > 0)
        {
            Move();
        }
        Dead();

        if (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            if(!deadYet) // If he is still alive.
                Shoot();

            waitTime = setTime;
        }
    }

   

    void Move()
    {

        if (!turn)
        {
            transform.Translate(new Vector3(0, 1, 0) * b_moveSpeed * Time.deltaTime);
        }
        else if (turn)
        {
            transform.Translate(new Vector3(0, -1, 0) * b_moveSpeed * Time.deltaTime);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("We collided");
            turn = !turn;
        }
    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(bigPewPew, transform.position, 1.0f);
       
       GameObject projectile = Instantiate(Misile, shootPos.transform.position, shootPos.transform.rotation);

    }

    public void DamangeBoss(float _dmg)
    {
        Debug.Log("Boss just got hit");
        boss_health -= _dmg;
    }

    void Dead()
    {

        if (boss_health <= 0)
        {
            //Debug.Log("We won!");
            if (!deadYet)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(deadBoss);
                Debug.Log("This");
                deadYet = true;
            }
            if (deadYet)
            {
                if (!gameObject.GetComponent<AudioSource>().isPlaying)
                {
                    SceneManager.LoadScene("Win");
                  //  Destroy(this.gameObject);
                    Debug.Log("Destroy");
                }
            }
            time += Time.deltaTime;
            if (time > nextPeriod)
            {
                BringExplosion();
                time = 0f;
            }


            //  Destroy(this.gameObject);
        }
    }

    void BringExplosion()
    {
        Mesh myMesh = gameObject.GetComponent<MeshFilter>().mesh;
        Bounds bounds = myMesh.bounds;

        float randz = Random.Range((Explosion_Panel.transform.position.z - Explosion_Panel.transform.localScale.x * 0.5f), (Explosion_Panel.transform.position.z + Explosion_Panel.transform.localScale.x * 0.5f));
        float randx = Random.Range((Explosion_Panel.transform.position.x - Explosion_Panel.transform.localScale.x * 0.5f), (Explosion_Panel.transform.position.x + Explosion_Panel.transform.localScale.x * 0.5f));
        float randy = Random.Range((Explosion_Panel.transform.position.y - Explosion_Panel.transform.localScale.y * 0.5f), (Explosion_Panel.transform.position.y + Explosion_Panel.transform.localScale.y * 0.5f));

        Vector3 pos = new Vector3(Explosion_Panel.transform.position.x, randy, randz);
        Debug.Log("Position: " + pos);
        //Vector3 transformPos = gameObject.transform.TransformPoint(pos);

        Instantiate(_explosion, pos, _explosion.transform.rotation);

    }

}
