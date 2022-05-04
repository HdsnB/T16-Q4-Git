using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject bubba;
    public GameObject fireball;
    public float fireTime;
    public float elapsedTime;

    Rigidbody2D rbFireball;

    void Start()
    {
        rbFireball = fireball.GetComponent<Rigidbody2D>();
        //CreateFireBall();

        bubba = GameObject.Find("Bubba");
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > fireTime)
        {
            CreateFireBall();
            elapsedTime = 0;
        }
    }

    public void CreateFireBall()
    {
        GameObject fb = Instantiate(fireball, this.transform.position, Quaternion.identity);
        float v;
        if(fb.transform.position.x > bubba.transform.position.x)
        {
            v = -5.0f;
            this.GetComponent<SpriteRenderer>().flipX = false;
        } else
        {
            v = 5.0f;
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        fb.GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0);

    }

}
