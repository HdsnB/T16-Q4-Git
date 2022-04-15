using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField]
    public int Damage = 1; 
    public GameObject Player;

    //public PlayerHealth PH;

    //public EnemyHealthScript EH;
    public bool IsProjectile = true;
    //hp bar mask
    public GameObject hpBarMask;
    public int Health;

    [SerializeField]
    public GameObject OuchSoundMaker;
    [SerializeField]
    public GameObject OuchSoundSpawnPoint;
    [SerializeField]
    public GameObject OuchSound;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Bubba");


        //PH = Player.GetComponent<PlayerHealth>();

        //GetComponent<EnemyHealthScript>();

        hpBarMask = GameObject.Find("HealthBarMask");
        //Health = PH.Health;
    }

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bubba")
        {
            GameObject OuchSound  = Instantiate(OuchSoundMaker, OuchSoundSpawnPoint.transform.position, Quaternion.identity);


           // PH.Health -= Damage;
           // hpBarMask.GetComponent<HealthBarMaskScript>().MoveHealthMask(Health, 100);

            Debug.Log("Damage");
            if (IsProjectile == true)
            {
                Destroy(this.gameObject);
            }
        }

        //if (collision.tag == "CanTakeDamage")
        //{
        //EH.Health -= Damage;
        //Debug.Log("Enemy Damaged");
        //}

        var enemy = collision.gameObject.GetComponent<EnemyHealthScript>();
        if (enemy)
        {
            enemy.TakeHit(Damage);
            Debug.Log("Enemy Damaged");
            if (IsProjectile == true)
            {
                //Destroy(this.gameObject);
            }
        }

        else
        {
            if(collision.tag == "Ground")
            {
                if (IsProjectile == true)
                {
                   // Destroy(this.gameObject);
                }
            }
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
