using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYBullet : MonoBehaviour
{ //CODE FROM SAME SHOOTING VIDEO FOR BULLET (Mike Scriven)

    //public float dieTime, damage;
    public AudioSource damage;
    public Animator anim;
    public Rigidbody2D Rib;
    public SpriteRenderer Sipt;


    public GameObject InLevelPlayer;
    void Start()
    {
        InLevelPlayer = GameObject.FindGameObjectWithTag("Player");
    }
    public void Update()
    {
        if (Rib.velocity.x < 0f)
        {
            Debug.Log("Working right");
            Sipt.flipX = false;
        } else
        {
            Debug.Log("Working left");
            Sipt.flipX = true;
        }
    }
    //public void OnCollosionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("HIT POGGERS");
    //        if(collision.gameObject.tag == "Player")
    //        {

    //            InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP = -1;
    //        }

    //        //Destroy(gameObject);
    //    }

    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enviroment" || collision.gameObject.tag == "Player")
        {
            Debug.Log("HIT POGGERS");
            if (collision.gameObject.tag == "Player")
            {
                //damage.Play();
                Destroy(this.gameObject);
                InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP -= 1;
                if (InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP > 0) damage.Play();
                Debug.Log("Destroy Fireball");
                //this.GetComponent<SpriteRenderer>().enabled = false;
                


            }
            //this.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(this.gameObject);

        }

    }



    //IEnumerator CountDownTimer()
    //{
    //    yield return new WaitForSeconds(dieTime);


    //    Destroy(gameObject);
    //}

}
