using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour {

    public CharacterClass characterClass;

    [SerializeField]
    protected UnityEvent OnSpawn;
    [SerializeField]
    protected UnityEvent OnDeath;

    private void Start() {
        OnSpawn.Invoke();
    }

    public virtual void SetCharacterClass(CharacterClass fighterClass) { characterClass = fighterClass; }
}

public enum CharacterClass {
    WARRIOR,
    RANGER,
    MAGE
}