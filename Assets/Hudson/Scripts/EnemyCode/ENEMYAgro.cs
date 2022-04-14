using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYAgro : MonoBehaviour
{ //CODE FROM THE FIRST VIDEO (ENEMY AGRO)
    [SerializeField]
    GameObject face;

    Animator faceAnimator;


    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    private Vector2 Direction = new Vector2(1, 0);
    private SpriteRenderer sprt;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        faceAnimator = face.GetComponent<Animator>();
        sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }

    }
    void ChasePlayer()
    {
        if(transform.position.x - player.position.x < -0.15f)
        {
            //enemy is to the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            sprt.flipX = false;
        }
        else if (transform.position.x - player.position.x > 0.15f)

        {
            //enemy is to the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            sprt.flipX = true;
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        //faceAnimator.Play("browmad"); NAME IS THE ANIMATION NAME AND CAN ADD LATER

    }
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        //faceAnimator.Play("brow"); NAME IS THE ANIMATION NAME AND CAN ADD LATER

    }

    private void Flip()
    {
        

        transform.Rotate(0f, 180f, 0f);

    }

}
