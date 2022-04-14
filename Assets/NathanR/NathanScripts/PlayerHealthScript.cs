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
            Die();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("MenuScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            LastCheckpoint = collision.gameObject;
        }

    }

    public void Die()
    {
        CurrentHP = StartingHP;
        transform.position = new Vector3 (LastCheckpoint.transform.position.x, LastCheckpoint.transform.position.y + 0.5f, 0f) ;
    }
}
