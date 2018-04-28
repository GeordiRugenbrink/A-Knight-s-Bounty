using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour {

    [SerializeField]
    private string _abilityButtonAxisName = "Fire1";
    [SerializeField]
    private Image _darkMask;

    [SerializeField]
    private Ability _ability;
    private Image _buttonImage;
    private AudioSource _audioSource;
    private float _cooldownDuration;
    private float _nextReadyTime;
    private float _cooldownLeftTime;
    private bool _cooldownComplete;

    void Start() {
        Initialize(_ability);
    }

    /// <summary>
    /// Checks if the cooldown is complete and proceeds to cast the ability. 
    /// Else the cooldown counts down till it's ready.
    /// </summary>
    void Update() {
        _cooldownComplete = (Time.time > _nextReadyTime);
        if (_cooldownComplete) {
            DisableMaskAndCooldownText();
            if (Input.GetButton(_abilityButtonAxisName)) {
                ButtonTriggered();
            }
        } else {
            Cooldown();
        }
    }
    /// <summary>
    /// counts down the cooldowntimer.
    /// Changes the fillamount of the darkmask of the ability.
    /// </summary>
    private void Cooldown() {
        _cooldownLeftTime -= Time.deltaTime;
        _darkMask.fillAmount = (_cooldownLeftTime / _cooldownDuration);
    }

    public void Initialize(Ability selectedAbility) {
        _ability = selectedAbility;
        _buttonImage = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        _buttonImage.sprite = _ability.sprite;
        _cooldownDuration = _ability.cooldown;
        DisableMaskAndCooldownText();
    }

    private void ButtonTriggered() {
        _nextReadyTime = Time.time + _cooldownDuration;
        _cooldownLeftTime = _cooldownDuration;
        _darkMask.enabled = true;

        _audioSource.clip = _ability.audio;
        //TODO: add sound queue
        _ability.TriggerAbility();
    }

    private void DisableMaskAndCooldownText() {
        _darkMask.enabled = false;
    }
}
