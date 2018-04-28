using UnityEngine;

public class LevelManager : MonoBehaviour {

    [SerializeField]
    private float _currentLevel = 1;
    [SerializeField]
    private float _currentExperiencePoints = 0;
    [SerializeField]
    private float _nextLevelExperience;

    private const float MAXIMUM_EXPERIENCE_POINTS = 100000;

    [SerializeField]
    private AnimationCurve _levelExperienceCurve;
    [SerializeField]
    private int _levelMax = 10;

    public float NextLevelExperience {
        get { return _nextLevelExperience; }
        set { _nextLevelExperience = value; }
    }

    public float CurrentExperience {
        get { return _currentExperiencePoints; }
        set { _currentExperiencePoints = value; }
    }

    public float CurrentLevel {
        get { return _currentLevel; }
        set { _currentLevel = value; }
    }

    private void Awake() {
        Utility.levelManager = this;
        NextLevelExperience = Mathf.Floor(_levelExperienceCurve.Evaluate((CurrentLevel / _levelMax)) * MAXIMUM_EXPERIENCE_POINTS);
    }

    public void LevelUp() {
        CurrentLevel++;
        CurrentExperience = 0;
        Utility.statManager.LevelUpStats();
        Utility.statManager.CurrentHealth += Utility.statManager.healthStatAmount;
        NextLevelExperience = Mathf.Floor(_levelExperienceCurve.Evaluate((_currentLevel / _levelMax)) * MAXIMUM_EXPERIENCE_POINTS);
    }

    public void AddExperiencePoints(float exp) {
        CurrentExperience += exp;
        if (CurrentExperience > NextLevelExperience) {
            float restExp = CurrentExperience - NextLevelExperience;
            LevelUp();
            AddExperiencePoints(restExp);
        }
    }
}