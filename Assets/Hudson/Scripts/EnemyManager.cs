using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject bubba;
    public float distanceToStopPatrol;
    public int counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(bubba.transform.position.x - this.transform.position.x)  < distanceToStopPatrol  )
        {

            this.GetComponent<EnemyPatrol>().enabled = false;
            this.GetComponent<EnemyFire>().enabled = true;
            if (counter == 1) this.GetComponent<EnemyFire>().CreateFireBall();
            counter++;

        } else
        {
            this.GetComponent<EnemyPatrol>().enabled = true;
            this.GetComponent<EnemyFire>().enabled = false;
            counter = 0;
            
            
        }
    }
}
