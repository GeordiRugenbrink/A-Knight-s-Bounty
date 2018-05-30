using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : Buffable {

    private float _damage;

    public Poison(StatManager target, bool isPersistant, float finishTime, int procs, float damage)
        : base(target, isPersistant, finishTime, procs) {
        _damage = damage;
    }

    public override void Apply(StatManager target) {
        base.Apply(target);
    }

    private void PoisonDamage(StatManager target) {
        target.TakeDamage(_damage, AttackType.POISON);
    }

    protected override void Proc() {
        PoisonDamage(Target);
    }
}
