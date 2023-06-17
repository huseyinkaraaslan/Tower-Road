using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject startPosition;

    private List<List<int>> numberOfMonsters = new List<List<int>>();

    public Transform monstersInGame;
    private int level, stage;
    private int lastTime, tempTime;
    private float timer = 0f;

    void Start()
    {
        for (int levels = 0; levels < 5; levels++)
        {
            numberOfMonsters.Add(new List<int>());
            for (int stages = 0; stages < 5; stages++)
            {
                switch (levels)
                {
                    case 0:
                        numberOfMonsters[levels].Add(stages);
                        numberOfMonsters[levels][stages] = 10;
                        break;

                    case 1:
                        numberOfMonsters[levels].Add(15);
                        numberOfMonsters[levels][stages] -= (stages * 3);                    
                        break;

                    case 2:
                        numberOfMonsters[levels].Add(15);
                        numberOfMonsters[levels][stages] -= (stages * 3);
                        break;

                    case 3:
                        numberOfMonsters[levels].Add(21);
                        numberOfMonsters[levels][stages] -= (stages * 5);                      
                        break;

                    case 4:
                        numberOfMonsters[levels].Add(21);
                        numberOfMonsters[levels][stages] -= (stages * 5);
                        break;

                }
            }
        }

        level = 1;
        stage = 1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (level == 1)
        {
            switch (stage)
            {
                case 1:
                    if (timer > 2f && numberOfMonsters[0][0] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[0], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[0][0]--;
                        if (numberOfMonsters[0][0] == 0)
                        {
                            level = 2;
                        }
                    }
                    break;                 
            }
        }
        else if (level == 2)
        {
            Debug.Log("seviye 2");
            switch (stage)
            {
                case 1:
                    if (timer > 2f && numberOfMonsters[1][0] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[0], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[1][0]--;
                        if (numberOfMonsters[1][0] == 0)
                        {
                            stage = 2;
                        }
                    }
                    break;

                case 2:
                    if (timer > 1.5f && numberOfMonsters[1][1] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[1], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[1][1]--;
                        if (numberOfMonsters[1][1] == 6 || numberOfMonsters[1][1] == 5 || numberOfMonsters[1][1] == 3)
                        {
                            stage = 1;
                        }
                        if (numberOfMonsters[1][1] == 0)
                        {
                            stage = 3;
                        }
                    }
                    break;
                case 3:
                    if (timer > 1.5f && numberOfMonsters[1][2] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[2], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[1][2]--;
                        if (numberOfMonsters[1][2] == 0)
                        {
                            stage = 4;
                        }
                    }
                    break;
                case 4:
                    if (timer > 2f && numberOfMonsters[1][3] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[3], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[1][3]--;
                        if (numberOfMonsters[1][3] == 0)
                        {
                            stage = 5;
                        }
                    }
                    break;
            }
        }
    }
}
