using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Stats : MonoBehaviour
{
    // Audio
    GameObject Ambient;
    public AudioClip DarkSoulDeath;

    // Global Scripts
    GameObject _worldScripts;
    public GameObject _DeadCanvas;

    // Stats
    int _health;
    int _kills;
    public int _currentLevel;
    public int _permanent_kills;
    // UI
    public TextMeshProUGUI Text_Kill;
    public Slider Health_Slider;
    public Slider Kills_Slider;
    public GameObject Pause_Menu;
    bool isActive;
    // public TextMeshProUGUI Text_Health;
    public TextMeshProUGUI Text_Timer;
    public TextMeshProUGUI Text_Level;
    // Use this for initialization
    void Start()
    {
        Ambient = GameObject.Find("Ambient_Sound");
        _worldScripts = GameObject.Find("_Scripts");
        _health = 100;
        Health_Slider.maxValue = _health;
        //  _permanent_kills = 40; // Remember to remove this line..
        _kills = 0;
        if (SceneManager.GetActiveScene().name != "underwater")
        {
            _currentLevel = 1;
        }
        else
        {
            _currentLevel = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_permanent_kills <= 40)
            Kills_Slider.value = _permanent_kills;
        
        Health_Slider.value = _health;

        CheckDeath();
        UpdateText();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            Pause(isActive);
        }

    }

    public void TakeDamage(int _damage)
    {
        _health -= _damage;
    }

    void CheckDeath()
    {
        if (_health <= 0)
        {
            _DeadCanvas.SetActive(true);
            Ambient.GetComponent<AudioSource>().volume = 0.0f;
            Camera.main.gameObject.AddComponent<AudioListener>();
            AudioSource.PlayClipAtPoint(DarkSoulDeath, Camera.main.gameObject.transform.position, 1.0f);
            _worldScripts.GetComponent<IfPlayerDead>().isDead = true;
            Destroy(this.gameObject);          
        }
    }

    void UpdateText()
    {
        // Text_Health.text = "Health: " + _health;
        Text_Kill.text = "Kills: " + _kills;
        Text_Level.text = "Level: " + _currentLevel;
        if (_worldScripts.GetComponent<BuyMenu>().isActive)
        {
            Text_Timer.gameObject.SetActive(true);
            Text_Timer.text = "x2 Damage: " + (int)_worldScripts.GetComponent<BuyMenu>().effectCooldown2 % 60;
        }
        else
        {
            Text_Timer.gameObject.SetActive(false);
        }
    }

    void Pause(bool _active)
    {
        if (!_active)
        {
            Time.timeScale = 1.0f;
        }

        if(_active)
        {
            Time.timeScale = 0.0f;        
        }
        Pause_Menu.SetActive(_active);
    }


    public void AddKillPoints(int _point)
    {
        _kills += _point;
        _permanent_kills += _point;
    }

    public void RemoveKillPoints(int _point)
    {
        _kills -= _point;
    }

    public int GetKills()
    {
        return _kills;
    }
}
