using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggersScript : MonoBehaviour
{
    public GameObject BossWall;
    public GameObject EndWall;
    public GameObject MidCutscene;
    private bool IsTriggered = false;
    public bool finnished = false;
    public Rigidbody2D rb;
    //public GameObject P;

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

                EndWall.SetActive(true);

                BossWall.SetActive(true);
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (finnished == false)
        {
            if (collision.tag == "Player")
            {

                MidCutscene.SetActive(true);
                

                IsTriggered = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }
}
