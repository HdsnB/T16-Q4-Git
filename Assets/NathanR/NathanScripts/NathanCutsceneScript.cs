using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NathanCutsceneScript : MonoBehaviour
{
    public float FrameDistance;
    public float creditsMove;
    public float creditsMoveMax;
    public string NextScene;

    // Start is called before the first frame update
    void Start()
    {
        creditsMove = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && creditsMove == creditsMoveMax)
        {
            SceneManager.LoadScene("HudCreditsScene");
        }
        else if (Input.GetButtonDown("Jump") && creditsMove != creditsMoveMax)
        {
            creditsMove++;
            transform.position = new Vector3(transform.position.x, transform.position.y - FrameDistance, transform.position.z);
        }
    }
}
