using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float _movementSpeed = 10f;

    [SerializeField]
    private float _damage = 10f;

    private void Awake() {
        Utility.RotateProjectile(transform);
    }

    private void Update() {
        Move();
    }

    public void Move() {
        transform.position += transform.right * _movementSpeed * Time.deltaTime;
    }

    public void DealDamage(float damage, Collider2D collider) {
        if (Utility.player.characterClass == CharacterClass.MAGE) {
            damage += Utility.statManager.MageStat;
        } else if (Utility.player.characterClass == CharacterClass.RANGER) {
            damage += Utility.statManager.RangedStat;
        }

        if (collider != null) {
            collider.GetComponent<EnemyHealthManager>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<EnemyHealthManager>()) {
            DealDamage(_damage, other);
            Destroy(gameObject);
        }
    }
}
