using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public Image[] hearts;

    public PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.HP;

        for (int i = 0; i < hearts.Length; i++) //3 , 0 1 2 ; 2, 0 1
        {
            if (i < health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
                if (playerHealth.HP == 0)
                {
                    hearts[0].enabled = false;
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Heart")
        {
            if (health < playerHealth.maxHP)
            {
                playerHealth.HP++;
                Destroy(collision.gameObject);
            }
        }
    }
}
