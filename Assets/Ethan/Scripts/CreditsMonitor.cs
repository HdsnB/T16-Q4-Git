using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMonitor : MonoBehaviour
{
    private static int nScreens = 8;
    private GameObject[] creditScenes = new GameObject[nScreens];
    private static int swapCount = 0;

    // Use this for initialization
    void Start()
    {
        creditScenes[0] = GameObject.Find("Credits1");
        creditScenes[1] = GameObject.Find("Credits2");
        creditScenes[2] = GameObject.Find("Credits3");
        creditScenes[3] = GameObject.Find("Credits4");
        creditScenes[4] = GameObject.Find("Credits5");
        creditScenes[5] = GameObject.Find("Credits6");


        //Turn all scenes off
        for (int i = 0; i < nScreens; i++)
        {
            creditScenes[i].SetActive(false);
        }

        creditScenes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            int CurrentScene = swapCount % nScreens;
            creditScenes[CurrentScene].SetActive(false);
            swapCount++;
            CurrentScene = swapCount % nScreens;
            creditScenes[CurrentScene].SetActive(true);
            Debug.Log(CurrentScene);
        }
    }
}