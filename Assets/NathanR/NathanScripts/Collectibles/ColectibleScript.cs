using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectibleScript : MonoBehaviour
{
    public int GivenWood;
    public int GivenStone;
    public int GivenDogs;
    public GameObject CT;
    bool isCage = false;

    // Start is called before the first frame update
    void Start()
    {
        CT = GameObject.Find("ColectiblesTracker");
    }

    //public void OnTriggerEnter2D(Collision2D collision)
    //{
    //    if (isCage == false)
    //    {
    //        if (collision.gameObject.tag == "Player")
    //        {
    //            Debug.Log("CollectScript trigger");
    //            CollectCollectible();
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    public void CollectCollectible()
    {
        if (CT != null) 
        {
            CT.GetComponent<ScoreTrackingScript>().GainCollectibles(GivenWood, GivenStone, GivenDogs);
            Debug.Log("Collect:" + GivenWood + GivenStone + GivenDogs);
        }
        else
        {
            Debug.Log("no colectible tracker");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
