using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondDisplay : MonoBehaviour
{
    public int diamond;
    public Image[] diamonds; //UI array of images
    public FinalDoors diamondcount;

    // Start is called before the first frame update
    void Start()
    {
        diamond = 0; //setting diamonds looted to 0
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < diamonds.Length; i++)
        {
            if (i < diamond) //depends on the amount of diamonds we have looted and then enabling/disabling image of diamond
            {
                diamonds[i].enabled = true;
            }
            else
            {
                diamonds[i].enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Diamond") //on collision with diamond tagged "Diamond" we +1 diamond and destroy him
        {
            diamond++;
            diamondcount.diamondcount++;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Diamond") //on collision with diamond tagged "Diamond" we +1 diamond and destroy him
        {
            diamond++;
            diamondcount.diamondcount++;
            Destroy(collision.gameObject);
        }
    }
}
