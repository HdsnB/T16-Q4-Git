using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonFirePoint : MonoBehaviour
{
    private SpriteRenderer sprt;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);


        if (transform.position.x - player.position.x < -0.15f)
        {
            //enemy is to the left side of the player, so move right
            sprt.flipX = false;
        }
        else if (transform.position.x - player.position.x > 0.15f)

        {
            //enemy is to the right side of the player,  so move left
            sprt.flipX = true;
        }
    }
}
