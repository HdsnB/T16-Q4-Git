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

    //dogs
    public GameObject Dog1;
    public GameObject Dog2;
    public GameObject Dog3;
    private float x;
    private float y;
    private float z;
    private Vector3 pos;
    private Vector3 pos2;
    private Vector3 pos3;

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        pos = new Vector3(x, y, z);
        pos = new Vector3(x-1, y, z);
        pos = new Vector3(x+1, y, z);
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
                if (this.tag == "Cage")
                {
                    if (this.GetComponent<ColectibleScript>().GivenDogs > 1)
                    {

                        Instantiate(Dog1, pos2, Quaternion.identity);
                        Instantiate(Dog2, pos, Quaternion.identity);
                        Instantiate(Dog3, pos3, Quaternion.identity);
                    }
                    else if(this.GetComponent<ColectibleScript>().GivenDogs == 1)
                    {
                        Instantiate(Dog1, pos, Quaternion.identity);
                    }
                    else
                    {
                        
                    }
                }
            }

            //DieSound.Play();
            Debug.Log("Enemy Dead");

            Destroy(gameObject);
        }
    }
}
