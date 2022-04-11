using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMoveScrip : MonoBehaviour
{
    private int creditsMove;
    private int creditsMoveMax;

    // Start is called before the first frame update
    void Start()
    {
        creditsMove = 0;
        creditsMoveMax = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            
            creditsMove++; 
            if ((creditsMove == creditsMoveMax))
            {
                //Debug.Log("Credits Camera Resset");
                //transform.position = new Vector3(transform.position.x, transform.position.y + 60, transform.position.z);
                //creditsMove -= 7;
                SceneManager.LoadScene("Menu UI");
            }
            else
            {
                Debug.Log("Credits Camera Move");
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
            }
            
        }
    }
}
