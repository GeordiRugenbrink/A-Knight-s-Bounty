using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseClass : MonoBehaviour {

    public GameObject archer;
    public GameObject mage;
    public GameObject archerUI;
    public GameObject mageUI;

    public void OnArcherClicked() {
        Utility.playerPrefab = archer;
        Utility.ui = archerUI;
        Play();
    }

    public void OnMageClicked() {
        Utility.playerPrefab = mage;
        Utility.ui = mageUI;
        Play();
    }

    public void Play() {
        SceneManager.LoadScene("Main");
    }
}
