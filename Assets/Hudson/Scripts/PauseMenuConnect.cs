using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuConnect : MonoBehaviour
{
    //public void ResumeGame()
    //{
    //    SceneManager.LoadScene("Resume The Game Somehow");
    //}


    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("HudCreditsScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
