using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public int StartingHP;
    public int CurrentHP;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = StartingHP;
        Debug.Log(CurrentHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP == 0)
        {
            Debug.Log("dead");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
