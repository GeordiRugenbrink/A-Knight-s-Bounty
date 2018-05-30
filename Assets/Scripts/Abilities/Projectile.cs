using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float _movementSpeed = 10f;
    [SerializeField]
    private float _timeToDestroy = 2f;
    [SerializeField]
    private AttackType _attackType;
    [SerializeField]
    private List<Buffable> debuffs = new List<Buffable>();

    [SerializeField]
    private float _damage = 10f;

    private void Awake() {
        debuffs.Add(new Poison(null, false, 5, 10, 5));
    }

    private void Update() {
        Move();
        Destroy(gameObject, _timeToDestroy);
    }

    public void Move() {
        transform.position += transform.right * _movementSpeed * Time.deltaTime;
    }

    public void DealDamage(float damage, Collider2D collider) {

        if (collider != null) {
            collider.GetComponent<StatManager>().TakeDamage(damage, _attackType);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<EnemyMovement>()) {
            if (other.GetComponent<StatManager>()) {
                DealDamage(_damage, other);
                foreach (var buff in debuffs) {
                    buff.Target = other.GetComponent<StatManager>();
                    other.GetComponent<StatManager>().AddBuffable(buff);
                }
                Destroy(gameObject);
            }
        }
    }
}
