using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYBullet : MonoBehaviour
{ //CODE FROM SAME SHOOTING VIDEO FOR BULLET (Mike Scriven)

    //public float dieTime, damage;

    public GameObject InLevelPlayer;
    void Start()
    {
        InLevelPlayer = GameObject.FindGameObjectWithTag("Player");
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

                InLevelPlayer.GetComponent<PlayerHealthScript>().CurrentHP -= 1;
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
