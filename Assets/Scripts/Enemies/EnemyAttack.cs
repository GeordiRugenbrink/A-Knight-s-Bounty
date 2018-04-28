using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    private EnemyMovement _enemyMovement;

    [SerializeField]
    private float _enemyAttackRange = 10f;

    private bool _canAttack = true;

    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _attackInterval;

    private void Awake() {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update() {

    }

    private void Attack() {

    }
}
