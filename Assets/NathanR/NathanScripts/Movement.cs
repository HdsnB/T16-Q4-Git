using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float cayoteRemember = 0;
    [SerializeField]
    float cayoteTime = 0.1f;
    float jumpStorage = 0f;
    [SerializeField]
    float jumpStorageTime = 0.1f;
    private int extraJumps;
    [SerializeField]
    private int extraJumpsValue;
    [SerializeField]
    private float jumpCut = 0.5f;
    public LayerMask ground;
    [SerializeField]
    private float jumpPower = 25f;
    private float horizontal;
    [SerializeField]
    private float moveSpeed = 12.5f;
    Rigidbody2D rb;
    public float fallMultiplier =  5f;

    private bool facingRight = true;

    public AudioSource jumpSound;
    public AudioSource DoubleJumpSound;
    public AudioSource Walk;

    // anim stuff ---------------------------------------------------------------------------------------------
    Animator a;
    bool Grounded = false;

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // anim stuff ---------------------------------------------------------------------------------------------
        a.SetFloat("yVelocity", rb.velocity.y);
        Grounded = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), 0, Vector2.down, 1, LayerMask.GetMask("ground"));
        a.SetBool("Grounded", Grounded); // detect ground

        if (rb.velocity.x > 0 || rb.velocity.x < 0)
        {
            Walk.Play();
        }

        float horizValue = Input.GetAxis("Horizontal"); //moveing/walking anim stuff

        if (Mathf.Abs(horizValue) <= 0.3f)
        {
            a.SetBool("Moving", false);
        }
        else
        {
            a.SetBool("Moving", true);
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded() == true) //jump function  && extraJumps > 0
        {
            Debug.Log("jump sound");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //Debug.Log("jump sound");
            //extraJumps--; not needed
            //Debug.Log("jump sound");
            jumpSound.Play(); //---------------------------------------------------------------------------------------------------------------------
            //.Log("jump sound");
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() == false && extraJumps >= 1) //jump counter
        {
            Debug.Log("jump sound 2");
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            //Debug.Log("jump sound 2");
            extraJumps--;
            //Debug.Log("jump sound 2");
            DoubleJumpSound.Play(); //---------------------------------------------------------------------------------------------------------------------
            //Debug.Log("jump sound 2");
        }

        Flip();

        if (Input.GetButtonUp("Jump")) //jump cut
        {
            if(rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpCut);
                //Debug.Log("jump cut");
            }
        }

        if (IsGrounded() == true) // double jump resset //
        {
            extraJumps = extraJumpsValue;
        }

        cayoteRemember -= Time.deltaTime; //cayote time//
        if (IsGrounded())
        {
            cayoteRemember = cayoteTime;
        }

        jumpStorage -= Time.deltaTime; 
        if (Input.GetButtonDown("Jump"))
        {
            jumpStorage = jumpStorageTime;
        }

        if((jumpStorage > 0) && (cayoteRemember > 0) && (IsGrounded() == false))  //Jump?????????????????????????????
        {
            jumpStorage = 0;
            cayoteRemember = 0;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpSound.Play();
        }

        //fast fall
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            facingRight = !facingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y); //basic movement//
    }

    public bool IsGrounded() 
    {
        bool grounded = Physics2D.BoxCast(transform.position + new Vector3(0f, 0f, 0f), new Vector3(0.75f, 1f, 0f), 0, Vector2.down, 0.7f, ground);
        return grounded;
    }
}
