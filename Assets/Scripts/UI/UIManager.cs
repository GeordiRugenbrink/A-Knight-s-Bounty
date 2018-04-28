using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Text healthText;

    public Slider experienceBar;
    public Text levelText;

    private void Awake() {
        Utility.uiManager = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        healthBar.maxValue = Utility.statManager.Health;
        healthBar.value = Utility.statManager.CurrentHealth;
        healthText.text = Utility.statManager.CurrentHealth + " / " + Utility.statManager.Health + " hp";

        experienceBar.maxValue = Utility.levelManager.NextLevelExperience;
        experienceBar.value = Utility.levelManager.CurrentExperience;
        levelText.text = "Level " + Utility.levelManager.CurrentLevel;
    }
}
