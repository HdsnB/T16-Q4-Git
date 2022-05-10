using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggersScript : MonoBehaviour
{
    public GameObject BossWall;
    public GameObject MidCutscene;
    private bool IsTriggered = false;
    private bool finnished = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTriggered == true && finnished == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                MidCutscene.SetActive(false);
                finnished = true;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (finnished == false)
        {
            if (collision.tag == "Player")
            {
                BossWall.SetActive(true);
                MidCutscene.SetActive(true);
                IsTriggered = true;
            }
        }
    }
}
