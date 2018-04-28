using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour {

    [SerializeField]
    private int _meleeStat = 1;
    [SerializeField]
    private int _rangedStat = 1;
    [SerializeField]
    private int _mageStat = 1;
    [SerializeField]
    private float _health = 100;
    private float _currentHealth = 100;

    [SerializeField]
    private Color color;
    private SpriteRenderer _renderer;
    [SerializeField]
    private float _flashTime;

    [Header("Stat amount gained on level up")]
    public int meleeStatAmount = 1;
    public int rangedStatAmount = 1;
    public int mageStatAmount = 1;
    public float healthStatAmount = 5;

    public int MeleeStat {
        get { return _meleeStat; }
    }

    public int RangedStat {
        get { return _rangedStat; }
    }

    public int MageStat {
        get { return _mageStat; }
    }

    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float Health {
        get { return _health; }
    }

    private void Awake() {
        Utility.statManager = this;
        _currentHealth = _health;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (_renderer.color != Color.white) {
            _renderer.color = Color.Lerp(_renderer.color, Color.white, _flashTime * Time.deltaTime);
        }
        Death();
    }

    public void LevelUpStats() {
        _meleeStat += meleeStatAmount;
        _mageStat += mageStatAmount;
        _rangedStat += rangedStatAmount;
        _health += healthStatAmount;
    }

    public void TakeDamage(float damage) {
        CurrentHealth -= damage;
        Utility.ChangeColor(color, _renderer);
    }

    public void Death() {
        if (CurrentHealth <= 0) {
            SceneManager.LoadScene("GameOver");
        }
    }
}