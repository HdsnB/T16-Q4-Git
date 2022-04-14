using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayerCollision : MonoBehaviour
{
    public GameObject spawnpoint;
    public GameObject mainPlayer;
    private Rigidbody2D rb2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("=======");
        //Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {

            rb2 = mainPlayer.GetComponent<Rigidbody2D>();

            if (mainPlayer.GetComponent<PlayerHealthScript>().LastCheckpoint == null)
            {
                rb2.velocity = new Vector2(0, 0);
                mainPlayer.transform.localPosition = spawnpoint.transform.localPosition;
            }
            else
            {
                mainPlayer.GetComponent<PlayerHealthScript>().Die();
            }
            
        }
    }

}
