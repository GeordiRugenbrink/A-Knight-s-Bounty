using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text healthText;

    public Slider experienceBar;
    public Text levelText;

    private StatManager statManager;

    private void Awake() {
        Utility.uiManager = this;
        statManager = Utility.player.GetComponent<StatManager>();
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        healthBar.maxValue = statManager.Health;
        healthBar.value = statManager.CurrentHealth;
        healthText.text = statManager.CurrentHealth + " / " + statManager.Health + " hp";

        experienceBar.maxValue = Utility.levelManager.NextLevelExperience;
        experienceBar.value = Utility.levelManager.CurrentExperience;
        levelText.text = "Level " + Utility.levelManager.CurrentLevel;
    }
}
