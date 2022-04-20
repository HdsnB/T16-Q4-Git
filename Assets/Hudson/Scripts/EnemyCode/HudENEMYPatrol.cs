using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudENEMYPatrol : MonoBehaviour
{ //CODE FROM ENEMY SHOOTING VIDEO (Mike Scriven)
    public float walkSpeed, range, timeBTWShots, shootSpeed;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform shootPos;
    private Transform player;
    public GameObject bullet;
    public GameObject Player;

    public float bulletLifetime;
    //public AudioSource pewSound;

    // anim stuff ---------------------------------------------------------------------------------------------
    
    //Animator a;
    bool isShooting;

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    void Start()
    {
        Player = GameObject.Find("WizardCat");
        player = Player.GetComponent<Transform>();
        mustPatrol = true;
        canShoot = true;

        // anim stuff ---------------------------------------------------------------------------------------------
        //a = GetComponent<Animator>();

        //bool isShooting = false;
    }


    void Update()
    {
        // anim stuff ---------------------------------------------------------------------------------------------
        
        //a.SetFloat("yVelocity", rb.velocity.y);
       // a.SetBool("IsShooting", isShooting);

        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            if (canShoot)
            {
                StartCoroutine(Shoot());
                //bool isShooting = true; 

              //  a.SetBool("IsShooting", true);
            }

        }
        else
        {
            mustPatrol = true;
            //bool isShooting = false;

           // a.SetBool("IsShooting", false);
        }

    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        // pewSound.Play();
        if(bullet == null)
        {
            Debug.Log("NO BULLET TO SHOOT!!!!");
        }
        Debug.Log("About to instantiate:    " + bullet.name);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        newBullet.transform.position = new Vector3(newBullet.transform.position.x, newBullet.transform.position.y, 30);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        Debug.Log("Shoot");
        Destroy(newBullet, bulletLifetime);

        void OnCollosionEnter2D(Collision2D col)
        {

            Destroy(newBullet); // CHANGE THIS SOME HOW?!??!?! I DONT EVEN KNOW...

        }

        canShoot = true;
        if (transform.position.x - player.position.x > 0f)
        {
            Debug.Log("bullet flip");
            newBullet.GetComponent<SpriteRenderer>().flipX = true;
        }
    }




}
