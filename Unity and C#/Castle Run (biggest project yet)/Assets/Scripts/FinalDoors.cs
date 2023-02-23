using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoors : MonoBehaviour
{
    public Animator ClosedDoors;
    public Animator Fade;

    public int diamondcount = 0;
    public int monstercount = 0;

    int maxmonsters;
    int maxdiamonds;

    public bool NextLevel;


    // Start is called before the first frame update
    void Start()
    {
        maxmonsters = GameObject.FindGameObjectsWithTag("Monster").Length;
        maxdiamonds = GameObject.FindGameObjectsWithTag("Diamond").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (diamondcount == maxdiamonds && monstercount == maxmonsters)
            {
                ClosedDoors.SetTrigger("OpenDoor");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (NextLevel == true)
        {
            Fade.SetTrigger("fade");
        }
    }

    public void NextLevelTrigger()
    {
        NextLevel = true;
    }
}
