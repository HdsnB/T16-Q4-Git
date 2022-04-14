using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudCredits : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
