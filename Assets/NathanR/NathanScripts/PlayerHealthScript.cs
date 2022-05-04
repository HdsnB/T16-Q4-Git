using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public int StartingHP;
    public int CurrentHP;
    public GameObject LastCheckpoint;
    Rigidbody2D rb;
    private GameObject cCP;
    private string cCPName;
    private string cCPName2;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        CurrentHP = StartingHP;
        Debug.Log(CurrentHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHP == 0)
        {
            Debug.Log("dead");
            anim.Play("BubbaDeath");
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Invoke("Die", 1);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("MenuScene");
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CurrentHP = 0;
        }
    }

    //checkpoint detector
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            LastCheckpoint = collision.gameObject;
            cCPName = collision.name;
            cCPName2 = cCPName.Substring(cCPName.Length - 1);
            cCP = GameObject.Find("check_point_copy_" + cCPName2);
            Debug.Log(cCP.name);
            cCP.GetComponent<CheckpointScript>().CheckpointSwap();
        }

    }

    public void Die()
    {
        CurrentHP = StartingHP;
        if (LastCheckpoint != null)
        {
            transform.position = new Vector3(LastCheckpoint.transform.position.x, LastCheckpoint.transform.position.y + 0.5f, 0f);
            Invoke("IdleAnim", 0.8f);

        }
        else
        {
            transform.position = new Vector3(-47,0,0);
            Invoke("IdleAnim", 0.8f);
            
        }
        
    }
    public void IdleAnim()
    {
        anim.Play("BunnaIdle");
    }
}
