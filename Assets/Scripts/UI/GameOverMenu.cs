using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {


    public void OnPlayAgainClicked() {
        SceneManager.LoadScene("Main");
    }

    public void OnMainMenuClicked() {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnQuitClicked() {
        Application.Quit();
    }
}
