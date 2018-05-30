using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/RadialeAbilities")]
public class RadialeProjectileAbility : Ability {

    [SerializeField]
    private int _numberOfProjectilesToSpawn = 8;
    [SerializeField]
    private float _angleStep = 360f;
    [SerializeField]
    private GameObject _projectileToSpawn;

    [SerializeField]
    private float _movementSpeedMultiplier;
    [SerializeField]
    private float _timeBonusMovementSpeed;
    [SerializeField]
    private bool _hasBonusMovementSpeed;
    private float _oldMovementSpeed;

    public override void TriggerAbility() {
        SpawnProjectile(_numberOfProjectilesToSpawn, _angleStep);
    }

    private void SpawnProjectile(int numberOfProjectiles, float angleStep) {
        angleStep /= numberOfProjectiles;
        float angle = 0f;
        for (int i = 0; i < numberOfProjectiles; i++) {
            angle = angleStep * i;
            var projectile = Instantiate(_projectileToSpawn, Utility.player.transform.position, Utility.player.transform.rotation);
            projectile.transform.localEulerAngles = new Vector3(0, 0, angle);
        }
    }
}
