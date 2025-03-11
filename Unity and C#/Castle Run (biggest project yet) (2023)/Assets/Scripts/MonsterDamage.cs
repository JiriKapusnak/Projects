using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    public PlayerHealth PlayerHP;
    public Player PlayerMovement;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Player Damage") && collision.gameObject.tag == "Player")
        {
            PlayerHP.TakeDamage(0);
        }

        else if(collision.gameObject.tag == "Player")
        {
            PlayerMovement.KBForce = 6;
            PlayerMovement.KBCounter = PlayerMovement.KBTotalTime;
            if (collision.transform.position.x < transform.position.x)
            {
                PlayerMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                PlayerMovement.KnockFromRight = false;
            }
            PlayerHP.TakeDamage(damage);
        }
    }
}
