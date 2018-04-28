using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    [SerializeField]
    private float _health = 50;
    [SerializeField]
    private float _currentHealth;
    private SpriteRenderer _renderer;

    [SerializeField]
    private Color flashColor;
    [SerializeField]
    private float flashTime;

    [SerializeField]
    private float experiencePoints;

    private void Awake() {
        _currentHealth = _health;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Death(experiencePoints);
        if (_renderer.color != Color.white) {
            _renderer.color = Color.Lerp(_renderer.color, Color.white, flashTime * Time.deltaTime);
        }
    }

    public void TakeDamage(float damage) {
        _currentHealth -= damage;
        Utility.ChangeColor(flashColor, _renderer);
    }

    private void Death(float experiencePoints) {
        if (_currentHealth <= 0) {
            //TODO: Add animation here
            Utility.levelManager.AddExperiencePoints(experiencePoints);
            Destroy(gameObject);
        }
    }
}
