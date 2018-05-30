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
    private int _armourStat = 0;
    [SerializeField]
    private int _magicArmourStat = 0;
    [SerializeField]
    private float _health = 100;
    [SerializeField]
    private float _currentHealth = 100;

    [SerializeField]
    private float _movementSpeed;
    private float _oldMovementSpeed;

    private List<Buffable> buffables = new List<Buffable>();

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

    public int ArmourStat {
        get { return _armourStat; }
    }

    public int MagicArmourStat {
        get { return _magicArmourStat; }
    }

    public float CurrentHealth {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public float Health {
        get { return _health; }
    }

    public float MovementSpeed {
        get { return _movementSpeed; }
        set { _movementSpeed = value; }
    }

    private void Awake() {
        _currentHealth = _health;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if (_renderer.color != Color.white) {
            _renderer.color = Color.Lerp(_renderer.color, Color.white, _flashTime * Time.deltaTime);
        }
        ApplyBuffables();
    }

    public void LevelUpStats() {
        _meleeStat += meleeStatAmount;
        _mageStat += mageStatAmount;
        _rangedStat += rangedStatAmount;
        _health += healthStatAmount;

    }
    /// <summary>
    ///     Does damage equal to the damage multiplied by a modifier of the defensive stats.
    /// </summary>
    /// <param name="damage">The base damage the attack does</param>
    /// <param name="attackType">An enum that checks for the attacktype (physical, magical or hybrid)</param>
    public void TakeDamage(float damage, AttackType attackType) {
        if (attackType == AttackType.PHYSICAL) {
            CurrentHealth -= damage * CalculateDamageModifier(ArmourStat);
        } else if (attackType == AttackType.MAGICAL) {
            CurrentHealth -= damage * CalculateDamageModifier(MagicArmourStat);
        } else if (attackType == AttackType.HYBRID) {
            CurrentHealth -= damage * ((CalculateDamageModifier(ArmourStat) + CalculateDamageModifier(MagicArmourStat)) / 2);
        } else {
            CurrentHealth -= damage;
        }

        CurrentHealth = Mathf.Round(CurrentHealth);
        Utility.ChangeColor(color, _renderer);
    }

    public void Slow(float slowMultiplier, float slowTimer) {
        _oldMovementSpeed = MovementSpeed;
        MovementSpeed *= slowMultiplier;
        float timer = slowTimer;
        timer -= Time.deltaTime;
        if (timer <= 0) {
            MovementSpeed = _oldMovementSpeed;
        }
    }

    public void ChangeStat(int statToChange, int amountToChangeStat) {
        statToChange += amountToChangeStat;
    }

    /// <summary>
    /// Calculates the damagemodifier by dividing 100% of the damage by 100% + the defensivestat.
    /// </summary>
    /// <param name="defensiveStat">The defensive stat which is added by the amount to divide by,
    /// to get a percentage of the damage to be reduced</param>
    /// <returns></returns>
    private float CalculateDamageModifier(int defensiveStat) {
        float modifier = 100 / (100 + defensiveStat);
        return modifier;
    }

    public void AddBuffable(Buffable buff) {
        buffables.Add(buff);
    }

    public void RemoveBuffable(Buffable buff) {
        buffables.Remove(buff);
    }

    private void ApplyBuffables() {
        for (int i = 0; i < buffables.Count; i++) {
            if (buffables[i] != null) {
                buffables[i].Apply(this);
                buffables[i].UpdateBuff();
                buffables.Remove(buffables[i]);
            }
        }
    }
}

public enum AttackType {
    PHYSICAL,
    MAGICAL,
    HYBRID,
    POISON
}