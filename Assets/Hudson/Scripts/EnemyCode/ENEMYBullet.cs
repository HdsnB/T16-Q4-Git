using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYBullet : MonoBehaviour
{ //CODE FROM SAME SHOOTING VIDEO FOR BULLET (Mike Scriven)

    //public float dieTime, damage;
    public AudioSource damage;
    private Animator anim;

    public GameObject InLevelPlayer;
    void Start()
    {
        InLevelPlayer = GameObject.FindGameObjectWithTag("Player");
        anim.Play("FireBallAnim");
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
                InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP -= 1;
                if (InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP > 0) damage.Play();
            }

            Destroy(gameObject);

        }

    }



    //IEnumerator CountDownTimer()
    //{
    //    yield return new WaitForSeconds(dieTime);


    //    Destroy(gameObject);
    //}

}
