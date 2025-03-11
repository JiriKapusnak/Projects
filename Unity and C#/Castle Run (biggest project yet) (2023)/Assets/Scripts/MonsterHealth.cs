using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{
    public int maxHP = 2;
    public int currentHP;
    public Material Flash;
    public Material Default;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void TakeDamage(int damage)
    {
        gameObject.GetComponent<Renderer>().material = Flash;
        var delay = Task.Delay(100);
        await delay;
        gameObject.GetComponent<Renderer>().material = Default;
        currentHP -= damage;
    }
}
