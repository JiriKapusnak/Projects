using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D PlayerRigidBody; //refenrence to rigidbody
    Animator PlayerAnimator; //reference to animator
    public SpriteRenderer spriteRenderer; //just spriterenderer to use flipping our player
    public float runspeed;
    public float input;

    public float jumpforce;
    public LayerMask groundLayer;
    private bool isGrounded; //if is on ground can jump, otherwise cannot
    public Transform feetPosition;
    public float groundCheckCircle; //we're creating small circle and checking if that circle overlaps with the ground
    private bool isJumping;
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;

    //variables for knockback
    public Animator playerAnim;
    public float KBForce = 6;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    // Start is called before the first frame update
    void Start()
    {
        //getting refences from unity
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0) //if you are going to left
        {
            PlayerAnimator.SetBool("Running", true);
            spriteRenderer.flipX = true;
        }
        else if (input > 0) //going to right
        {
            PlayerAnimator.SetBool("Running", true);
            spriteRenderer.flipX = false;
        }
        else //standing
        {
            PlayerAnimator.SetBool("Running", false);
        }

        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer); //true or false value if we're on a ground (creates small invinsible circle at player feet and checks if it overlaps with ground)


        if (isGrounded == true && Input.GetButtonDown("Jump")) //this means if jump is only clicked
        {
            isJumping = true;
            jumpTimeCounter = jumpTime; //everytime we jump we reset the timer
            PlayerRigidBody.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetButton("Jump") && isJumping == true) //this means if jump is holded and we're not jumping
        {
            if (jumpTimeCounter > 0)
            {
                PlayerRigidBody.velocity = Vector2.up * jumpforce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            PlayerRigidBody.velocity = new Vector2(input * runspeed, PlayerRigidBody.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                PlayerRigidBody.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                PlayerRigidBody.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime; //Makes knockback counter go to zero unless it already is
        }
    }
}
