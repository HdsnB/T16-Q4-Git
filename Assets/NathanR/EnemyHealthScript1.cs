using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float Health = 10;
    [SerializeField]
    public float StartingHealth = 10;
    public AudioSource DieSound;

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
        if (Health <= 0)
        {
            DieSound.Play();
            //Debug.Log("Enemy Dead");

            Destroy(gameObject);
        }
    }
}
