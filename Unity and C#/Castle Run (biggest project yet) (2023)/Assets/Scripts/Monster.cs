using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using System;

public class Monster : MonoBehaviour
{
    public Rigidbody2D MonsterRigidBody;
    public float runspeed = 1.5f;
    public bool goingright = true;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public Boolean KnockFromRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    public void Run()
    {
        if (goingright)
        {
            if (KBCounter <= 0)
            {
                MonsterRigidBody.velocity = new Vector2(1 * runspeed, MonsterRigidBody.velocity.y);
            }
            else
            {
                if (KnockFromRight == true)
                {
                    MonsterRigidBody.velocity = new Vector2(-KBForce, MonsterRigidBody.velocity.y);
                }
                if (KnockFromRight == false)
                {
                    MonsterRigidBody.velocity = new Vector2(KBForce, MonsterRigidBody.velocity.y);
                }
                KBCounter -= Time.deltaTime; //Makes knockback counter go to zero unless it already is
            }
        }
        else if (!goingright)
        {
            if (KBCounter <= 0)
            {
                MonsterRigidBody.velocity = new Vector2(-1 * runspeed, MonsterRigidBody.velocity.y);
            }
            else
            {
                if (KnockFromRight == true)
                {
                    MonsterRigidBody.velocity = new Vector2(-KBForce, MonsterRigidBody.velocity.y);
                }
                if (KnockFromRight == false)
                {
                    MonsterRigidBody.velocity = new Vector2(KBForce, MonsterRigidBody.velocity.y);
                }
                KBCounter -= Time.deltaTime; //Makes knockback counter go to zero unless it already is
            }
        }

        MonsterFlip(); //we always wanna flip the monster only while running
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rotate"))
        {
            goingright = true;
        }

        else if (collision.gameObject.CompareTag("Rotate2"))
        {
            goingright = false;
        }
    }

    private void MonsterFlip()
    {
        bool runninghorizontaly = Mathf.Abs(MonsterRigidBody.velocity.x) > Mathf.Epsilon; //this checks if player is running, we dont compare it to 0 because sometimes it bugs
        if (runninghorizontaly)
        {
            transform.localScale = new Vector2(-Mathf.Sign(MonsterRigidBody.velocity.x), 1f); //same as in player but we've used -mathf.sign cause monster has already x scaled to -1
        }
    }
}
