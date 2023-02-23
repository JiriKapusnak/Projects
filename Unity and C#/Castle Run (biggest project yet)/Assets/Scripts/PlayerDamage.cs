using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Animator playerAnim;
    public MonsterHealth monsterHP;
    public Monster MonsterMovement;
    public FinalDoors monstercount;
    public int damage;

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
        if (collision.gameObject.tag == "Monster")
        {
            monsterHP = collision.gameObject.GetComponent<MonsterHealth>();
            MonsterMovement = collision.gameObject.GetComponent<Monster>();
        }

        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Player Damage") && collision.gameObject.tag == "Monster")
        {
            MonsterMovement.KBCounter = MonsterMovement.KBTotalTime;
            if (collision.transform.position.x < transform.position.x)
            {
                MonsterMovement.KnockFromRight = true;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                MonsterMovement.KnockFromRight = false;
            }

            if (monsterHP.currentHP <= 1)
            {
                Destroy(collision.gameObject);
                monsterHP.currentHP = monsterHP.maxHP;
                monstercount.monstercount++;
            }
            else
            {
                monsterHP.TakeDamage(damage);
            }
        }
    }
}
