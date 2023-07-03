using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDie : MonoBehaviour
{
    private int healthy = 0;
    public string monsterName;

    private void Start()
    {
        switch (this.gameObject.name)
        {
            case "Small Dragon(Clone)":
                healthy = 20;
                break;

            case "Lizard(Clone)":
                healthy = 50;
                break;

            case "Medusa(Clone)":
                healthy = 150;
                break;

            case "Jinn(Clone)":
                healthy = 250;
                break;

            case "Dragon(Clone)":
                healthy = 400;
                break;

            case "Demon(Clone)":
                healthy = 750;
                break;
        }
    }

    private void Update()
    {
        monsterName = this.gameObject.name;

        if (healthy <= 0)
        {
            FindObjectOfType<Balance>().increaseBalance();          
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tower1(Clone)")
        {
            healthy -= 5;
        }
        else if(collision.gameObject.name == "Tower2(Clone)")
        {
            healthy -= 7;
        }
        else if (collision.gameObject.name == "Tower3(Clone)")
        {
            healthy -= 10;
        }
        else if (collision.gameObject.name == "Tower4(Clone)")
        {
            healthy -= 15;
        }
        else if (collision.gameObject.name == "Tower5(Clone)")
        {
            healthy -= 25;
        }
        else if (collision.gameObject.name == "Tower6(Clone)")
        {
            healthy -= 35;
        }
    }
}
