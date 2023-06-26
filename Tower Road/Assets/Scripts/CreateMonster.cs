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
                    case 0: //level 1
                        numberOfMonsters[levels].Add(stages);
                        numberOfMonsters[levels][stages] = 10;
                        break;

                    case 1://level 2
                        numberOfMonsters[levels].Add(13);
                        numberOfMonsters[levels][stages] -= (stages * 6);//(stages)(monsters) // (0)(13), (1)(7) ---> in the last stage will be 1 monster                       
                        break;

                    case 2://level 3
                        numberOfMonsters[levels].Add(13);
                        numberOfMonsters[levels][stages] -= (stages * 4);//(stages)(monsters) // (0)(13), (1)(9), (2)(5) ---> in the last stage will be 5 monster
                        break;

                    case 3://level 4
                        numberOfMonsters[levels].Add(30);
                        numberOfMonsters[levels][stages] -= (stages * 8);//(stages)(monsters) // (0)(30), (1)(22), (2)(14), (3)(6) ---> in the last stage will be 6 monster                  
                        break;

                    case 4://level 5
                        numberOfMonsters[levels].Add(21);
                        numberOfMonsters[levels][stages] -= (stages * 5);//(stages)(monsters) // (0)(21), (1)(16), (2)(11), (3)(6), (4)(1) ---> in the last stage will be 1 monster
                        break;

                }
            }
        }

        level = 3;
        stage = 1;
    }

    void Update()
    {        
        timer += Time.deltaTime;

        Debug.Log("level " + level);
        Debug.Log("stage " + stage);

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
            switch (stage)
            {
                case 1:
                    if (timer > 2f && numberOfMonsters[1][0] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[0], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[1][0]--;
                        if (numberOfMonsters[1][0] == 10 || numberOfMonsters[1][0] == 9 || numberOfMonsters[1][0] == 7 || 
                            numberOfMonsters[1][0] == 3 || numberOfMonsters[1][0] == 2 || numberOfMonsters[1][0] == 0)
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
                        if (numberOfMonsters[1][1] == 6 || numberOfMonsters[1][1] == 5 || numberOfMonsters[1][1] == 3 ||
                            numberOfMonsters[1][1] == 2)
                        {
                            stage = 1;
                        }
                        if(numberOfMonsters[1][1] == 1)
                        {
                            level = 3;
                            stage = 1;
                        }
                    }
                    break;          
            }
        }

        else if (level == 3)
        {
            switch (stage)
            {
                case 1:
                    if (timer > 2f && numberOfMonsters[2][0] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[0], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[2][0]--;
                        if (numberOfMonsters[2][0] == 8 || numberOfMonsters[2][0] == 7 || numberOfMonsters[2][0] == 6 || 
                            numberOfMonsters[2][0] == 4 || numberOfMonsters[2][0] == 2 || numberOfMonsters[2][0] == 1 || numberOfMonsters[2][0] == 0 )
                        {
                            stage = 2;
                        }
                    }
                    break;

                case 2:
                    if (timer > 1.5f && numberOfMonsters[2][1] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[1], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[2][1]--;
                        if (numberOfMonsters[2][1] == 8 || numberOfMonsters[2][1] == 5 || numberOfMonsters[2][1] == 4 || numberOfMonsters[2][1] == 1)
                        {
                            stage = 1;
                        }
                        if (numberOfMonsters[2][1] == 6 || numberOfMonsters[2][1] == 2  || numberOfMonsters[2][1] == 0)
                        {
                            stage = 3;
                        }
                    }
                    break;

                case 3:
                    if (timer > 1.5f && numberOfMonsters[2][2] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[2], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[2][2]--;
                        if (numberOfMonsters[2][2] == 4 || numberOfMonsters[2][2] == 3 || numberOfMonsters[2][2] == 2 || numberOfMonsters[2][2] == 1)
                        {
                            stage = 2;
                        }
                        if(numberOfMonsters[2][2] == 0)
                        {
                            level = 4;
                            stage = 1;
                        }
                    }
                    break;
            }
        }

        else if (level == 4) 
        {
            switch (stage)
            {
                case 1:
                    if (timer > 2f && numberOfMonsters[3][0] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[0], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[3][0]--;
                        if (numberOfMonsters[3][0] % 3 == 0 || numberOfMonsters[3][0] % 4 == 0 || numberOfMonsters[3][0] % 5 == 0 ||
                            numberOfMonsters[3][0] == 1 || numberOfMonsters[1][0] == 0)  // 0 1 3 4 5 6 8 9 10 12 15 16 18 20 21 24 25 27 28 
                        {
                            stage = 2;
                        }
                    }
                    break;

                case 2:
                    if (timer > 1.5f && numberOfMonsters[3][1] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[1], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[3][1]--;
                        if (numberOfMonsters[3][1] % 3 == 0  || numberOfMonsters[3][1] == 1)  // 1 3 6 9 12 15 18 21 
                        {
                            stage = 1;
                        }
                        if (numberOfMonsters[3][1] % 4 == 0 || numberOfMonsters[3][1] == 0) // 0 4 8 12 16 20
                        {
                            stage = 3;
                        }
                    }
                    break;
                case 3:
                    if (timer > 1.5f && numberOfMonsters[3][2] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[2], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[3][2]--;
                        if (numberOfMonsters[3][2] % 3 == 0) // 3 6 9 12 
                        {
                            stage = 2;
                        }
                        if (numberOfMonsters[3][2] == 10 || numberOfMonsters[3][2] == 5 || numberOfMonsters[3][2] == 1 || numberOfMonsters[3][2] == 0)
                        {
                            level = 4;
                        }
                    }
                    break;
                case 4:
                    if (timer > 2f && numberOfMonsters[3][3] > 0)
                    {
                        GameObject newMonster = Instantiate(monsters[3], startPosition.transform.position, Quaternion.identity);
                        newMonster.transform.SetParent(monstersInGame);
                        timer = 0f; numberOfMonsters[3][3]--;
                        if (numberOfMonsters[3][3] == 5 || numberOfMonsters[3][3] == 4 || numberOfMonsters[3][3] == 2 || numberOfMonsters[3][3] == 1)
                        {
                            stage = 3;
                        }
                        if(numberOfMonsters[3][3] == 0)
                        {
                            level = 5;
                            stage = 1;
                        }
                    }
                    break;
            }
        }
    }
}
