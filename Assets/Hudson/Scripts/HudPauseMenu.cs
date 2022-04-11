using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudPauseMenu : MonoBehaviour
{
    public bool pausemenu;
    public GameObject pausemenumenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausemenu == false)
            {
                openPausemenu();
                pausemenu = true;
            }
            else if (pausemenu == true)
            {
                Closepausemenu();
                pausemenu = false;
            }

        }
    }
    public void openPausemenu()
    {
        Time.timeScale = 0;
        pausemenumenu.SetActive(true);
    }

    public void Closepausemenu()
    {
        pausemenumenu.SetActive(false);
        Time.timeScale = 1;
    }
}
