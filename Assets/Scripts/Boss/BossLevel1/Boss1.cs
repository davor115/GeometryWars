using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Boss1 : MonoBehaviour
{

    bool go;

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
    public GameObject[] shootPos;
    public GameObject Projectile;
    float timerr = 3.5f;
    public GameObject _explosion;


    // Use this for initialization
    void Start()
    {
        go = false;
        b_moveSpeed = 6.0f;
        turn = false;
        shootPos = GameObject.FindGameObjectsWithTag("ShootPosition");
        setTime = .5f;
        waitTime = setTime;
        boss_health = 400f;
        Slider_health.maxValue = boss_health; // Set the max value of the slider to be the health.
    }

    // Update is called once per frame
    void Update()
    {
        Slider_health.value = boss_health; // Set the value of the health slider to be equal to the health.
        if (boss_health > 0)
        {
            Move(); // If the boss is still alive, move him.
        }
        Dead(); // check if the boss is dead.

        if (waitTime >= 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {   
            if(!deadYet)
                Shoot(); // Show while the boss is still alive.

            waitTime = setTime;
        }

        if(go)
        {
            
            if(timerr > 0)
            {
                timerr -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("underwater");
            }
        }

    }

    IEnumerator CheckOutsideCamera()
    {
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(GameObject.Find("Left_Check").transform.position); // get the position of the boss left point and transform it to view port point.
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1; // We check if the boss left point is in the screen.

        Vector3 screenPoint2 = Camera.main.WorldToViewportPoint(GameObject.Find("Right_Check").transform.position); // get the position of the boss right point and transform it to view port point.
        bool onScreen2 = screenPoint2.z > 0 && screenPoint2.x > 0 && screenPoint2.x < 1 && screenPoint2.y > 0 && screenPoint2.y < 1; // We check if the boss right point is in the screen.

        if (!turn && !onScreen)
        {
            turn = true;
        }
        else if(turn && !onScreen2)
        {
            turn = false;
        }
        yield return new WaitForSeconds(1.0f);
    }

    void Move()
    {
        StartCoroutine(CheckOutsideCamera());
        if (!turn) // If we don't need to turn
        {
            transform.Translate(new Vector3(1, 0, 0) * b_moveSpeed * Time.deltaTime);         // move left 
        }
        else if (turn) // Turn now.
        {
          transform.Translate(new Vector3(-1, 0, 0) * b_moveSpeed * Time.deltaTime);          // Move right  
        }
       

    }

    void Shoot()
    {
        AudioSource.PlayClipAtPoint(bigPewPew, transform.position, 1.0f); // Play a shooting sound effect.
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject projectile = Instantiate(Projectile, shootPos[i].transform.position, shootPos[i].transform.rotation); // Instantiate the bullet.
            //Debug.Log("Fire!");
        }
    }

    public void DamangeBoss(float _dmg)
    {
        Debug.Log("Boss just got hit");
        boss_health -= _dmg;
    }

    void Dead()
    {

        if (boss_health <= 0) // If the boss health is less than 0
        {
            //Debug.Log("We won!");
            if(!deadYet) // If we still don't call it dead.
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(deadBoss); // Play the death sound effect.
              //  Debug.Log("This");
                deadYet = true; // Now he is dead.
            }
            if (deadYet) // If he is dead
            {
                if (!gameObject.GetComponent<AudioSource>().isPlaying) // and the sound effect is no longer playing.
                {
                    go = true; // Set this boolean to true which will change the scene.
                   // Destroy(this.gameObject);
                 //   Debug.Log("Destroy");
                }
            }
            time += Time.deltaTime;
            if (time > nextPeriod)
            {
                BringExplosion(); // Make explosions appear if the boss has 0 health.
                time = 0f;
            }


          //  Destroy(this.gameObject);
        }
    }

    void BringExplosion()
    {
        // This will generate a random point on the Boss mesh using it's position and scale. This point will be use to instantiate the explosions.
        Mesh myMesh = gameObject.GetComponent<MeshFilter>().mesh;
        Bounds bounds = myMesh.bounds;

        float randz = Random.Range((gameObject.transform.position.z - gameObject.transform.localScale.x * 0.5f), (gameObject.transform.position.z + gameObject.transform.localScale.x * 0.5f));
        float randx = Random.Range((gameObject.transform.position.x - gameObject.transform.localScale.x * 0.5f), (gameObject.transform.position.x + gameObject.transform.localScale.x * 0.5f));
        float randy = Random.Range((gameObject.transform.position.y - gameObject.transform.localScale.y * 0.5f), (gameObject.transform.position.y + gameObject.transform.localScale.y * 0.5f));

        Vector3 pos = new Vector3(gameObject.transform.position.x - 3.5f, randy, randz);
        Debug.Log("Position: " + pos);
        //Vector3 transformPos = gameObject.transform.TransformPoint(pos);

        Instantiate(_explosion, pos, _explosion.transform.rotation);

    }

}
