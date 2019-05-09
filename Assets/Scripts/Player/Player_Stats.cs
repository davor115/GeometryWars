using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player_Stats : MonoBehaviour {

    // Global Scripts
    GameObject _worldScripts;

    // Stats
    int _health;
    int _kills;
    public int _currentLevel;
    public int _permanent_kills;
    // UI
    public TextMeshProUGUI Text_Kill;
    public TextMeshProUGUI Text_Health;
    public TextMeshProUGUI Text_Timer;
    public TextMeshProUGUI Text_Level;
    // Use this for initialization
    void Start()
    {
        _worldScripts = GameObject.Find("_Scripts");
        _health = 20;
        _permanent_kills = 40;
        _kills = 0;
        _currentLevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text_Health.text = "Health: " + _health;
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

    public void TakeDamage(int _damage)
    {
        _health -= _damage;
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
