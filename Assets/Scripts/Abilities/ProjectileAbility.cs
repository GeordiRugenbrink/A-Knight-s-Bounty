using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/ProjectileBased")]
public class ProjectileAbility : Ability {

    [SerializeField]
    private GameObject projectileToSpawn;

    public override void TriggerAbility() {
        var projectile = Instantiate(projectileToSpawn, Utility.player.transform.position, Utility.player.transform.rotation);
        Utility.RotateProjectileToMouse(projectile.transform);
    }
}
