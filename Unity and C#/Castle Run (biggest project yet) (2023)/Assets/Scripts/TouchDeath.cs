using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchDeath : MonoBehaviour
{
    public PlayerHealth heatlh;
    public GameOverScreen death;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            heatlh.HP = 0;
            int scene = SceneManager.GetActiveScene().buildIndex;
            death.Setup(scene - 2);
        }
    }
}
