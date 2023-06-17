using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private List<GameObject> monstersInGameList = new List<GameObject>();

    private GameObject target;
    private GameObject monstersInGameParent;
    private int targetCount, level;
    void Start()
    {
        target = GameObject.Find("Targets");
        monstersInGameParent = GameObject.Find("MonstersInGame");
        targetCount = 0;
        
    }

    void Update()
    {
        monsterMove();
        getMonsters();
    }

    private void monsterMove()
    {
        if (targetCount % 2 == 0)
        {
            if(gameObject.name == "Dragon(Clone)" || gameObject.name == "Small Dragon(Clone)")
            {
                transform.Translate(Time.deltaTime * 1.4f, 0, 0);
            }
            if (gameObject.name == "Jinn(Clone)")
            {
                transform.Translate(Time.deltaTime * 1.5f, 0, 0);
            }
            transform.Translate(Time.deltaTime * 1.3f , 0, 0);                
        }
        else
        {
            if (target.transform.GetChild(targetCount - 1).transform.position.y < target.transform.GetChild(targetCount).transform.position.y)
            {
                if(gameObject.name == "Dragon(Clone)" || gameObject.name == "Small Dragon(Clone)")
                {
                    transform.Translate(0, Time.deltaTime * 1.4f, 0);
                }
                if (gameObject.name == "Jinn(Clone)")
                {
                    transform.Translate(0, Time.deltaTime * 1.5f, 0);
                }
                transform.Translate(0, Time.deltaTime *1.3f , 0);
            }
            else
            {
                if (gameObject.name == "Dragon(Clone)" || gameObject.name == "Small Dragon(Clone)")
                {
                    transform.Translate(0, -Time.deltaTime * 1.4f, 0);
                }
                if (gameObject.name == "Jinn(Clone)")
                {
                    transform.Translate(0, -Time.deltaTime * 1.5f, 0);
                }
                transform.Translate(0, -Time.deltaTime * 1.3f, 0);
            }
        }   
    }

    private void getMonsters()
    {
        for(int i=0; i<1; i++)
        {
            monstersInGameList.Add(monstersInGameParent.transform.GetChild(i).gameObject);            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            targetCount++;
        }
    }
}
