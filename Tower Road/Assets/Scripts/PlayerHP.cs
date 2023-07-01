using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    private int hp;
    public Text hpText;
    
    void Start()
    {
        hp = 100;
    }

    void Update()
    {
        hpText.text = hp.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Small Dragon(Clone)")
        {
            hp -= 3;
        }
        if (collision.gameObject.name == "Lizard(Clone)")
        {
            hp -= 7;
        }
        if (collision.gameObject.name == "Medusa(Clone)")
        {
            hp -= 9;
        }
        if (collision.gameObject.name == "Jinn(Clone)")
        {
            hp -= 11;
        }
        if (collision.gameObject.name == "Dragon(Clone)")
        {
            hp -= 17;
        }
        if (collision.gameObject.name == "Demon(Clone)")
        {
            hp -= 30;
        }
    }
}
