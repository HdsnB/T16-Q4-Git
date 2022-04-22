using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float Health = 1;
    [SerializeField]
    public float StartingHealth = 1;
    public AudioSource DieSound;
    public bool isCollectible = false;

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeHit (float damage)
    {
        Health -= damage;
        Debug.Log("Enemy Hit");
        if (Health <= 0)
        {
            if (isCollectible == true)
            {
                this.GetComponent<ColectibleScript>().CollectCollectible();
            }

            //DieSound.Play();
            Debug.Log("Enemy Dead");

            Destroy(gameObject);
        }
    }
}
