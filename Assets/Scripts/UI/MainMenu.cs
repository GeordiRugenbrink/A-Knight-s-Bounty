using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void OnPlayClicked() {
        SceneManager.LoadScene("Class Selection");
    }

    public void OnQuitClicked() {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
