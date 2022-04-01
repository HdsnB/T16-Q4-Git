using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudMainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //or can use SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); which basically gets the number in the build settings
        SceneManager.LoadScene("NathanScene");
    }


    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("HudCreditsScene");
    }


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
