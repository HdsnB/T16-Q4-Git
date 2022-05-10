using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTrackerScript : MonoBehaviour
{
    public GameObject P;
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;
    public GameObject H4;
    public int HP;
    //public int MaxHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HP = P.GetComponent<PlayerHealthScript>().CurrentHP;
        //MaxHP = P.GetComponent<PlayerHealthScript>().StartingHP;
        if (HP <= 3)
        {
            H1.SetActive(false);
            //H2.SetActive(true);
            //H3.SetActive(true);
            //H4.SetActive(true);
            if (HP <= 2)
            {
                H2.SetActive(false);
                H3.SetActive(true);
                H4.SetActive(true);
                if (HP <= 1)
                {
                    H3.SetActive(false);
                    H4.SetActive(true);
                }
                else
                {
                    H3.SetActive(true);
                    H4.SetActive(true);
                }
            }
            else
            {
                H2.SetActive(true);
                H3.SetActive(true);
                H4.SetActive(true);
            }
        }
        else
        {
            H1.SetActive(true);
            H2.SetActive(true);
            H3.SetActive(true);
            H4.SetActive(true);
        }
    }
}
