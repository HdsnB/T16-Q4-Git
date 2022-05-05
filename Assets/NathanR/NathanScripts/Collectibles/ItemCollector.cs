using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int rock = 0;
    //private int wood = 0;

    [SerializeField] private Text rockText;
    //[SerializeField] private Text woodText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Destroy(collision.gameObject);
            rock++;

            Debug.Log("Rock: " + rock);

            rockText.text = "Rock {0}/15" + rock;
        }
        
        //if (collision.gameObject.CompareTag("Wood"))
        //{
        //    Destroy(collision.gameObject);
        //    wood++;

        //    Debug.Log("Wood: " + wood);
        //}


    }


}
