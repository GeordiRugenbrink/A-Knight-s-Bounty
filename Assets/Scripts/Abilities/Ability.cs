using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject {

    public string abilityName = "New Ability";
    public Sprite sprite;
    public AudioClip audio;
    public float cooldown = 1f;

    public abstract void TriggerAbility();
}
