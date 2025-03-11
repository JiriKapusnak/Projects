using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    public bool doDamage = false;
    public bool oneAnimation = true;
    public bool DamageDone = false;
    public int damage;
    float KBForceBefore;


    public Animator bombanim;
    public PlayerHealth PlayerHP;
    public Player PlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DamageDone == true)
        {
            KnockBack();
            DamageDone = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        doDamage = true;

        if (collision.gameObject.tag == "Player" && oneAnimation == true)
        {
            bombanim.SetTrigger("bomb off");
            oneAnimation = false;
        }
    }

    public void EnableBoom()
    {
        bombanim.SetTrigger("boom");
    }

    public void DoPlayerDamage()
    {
        if (doDamage == true) 
        {
            PlayerHP.HP -= damage;
            DamageDone = true;
        }
    }

    public void KnockBack()
    {
        PlayerMovement.KBCounter = PlayerMovement.KBTotalTime;
        KBForceBefore = PlayerMovement.KBForce;
        PlayerMovement.KBForce = 25;

        if (GameObject.Find("Player").transform.position.x < GameObject.Find("Bomb").transform.position.x)
        {
            PlayerMovement.KnockFromRight = true;
        }
        if (GameObject.Find("Player").transform.position.x > GameObject.Find("Bomb").transform.position.x)
        {
            PlayerMovement.KnockFromRight = false;
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
        PlayerMovement.KBForce = KBForceBefore;
    }
}
