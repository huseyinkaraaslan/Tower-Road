using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    public int _balance = 50;
    [SerializeField] private Text balanceText;

    private void Start()
    {
        balanceText.text = _balance.ToString() + " $";
    }

    private void Update()
    {
        balanceText.text = _balance.ToString() + " $";
    }

    public void updateBalance(string tower)
    {
        switch (tower)
        {
            case "Tower1(Clone)":
                _balance -= 50;
                break;

            case "Tower2(Clone)":
                _balance -= 100;
                break;

            case "Tower3(Clone)":
                _balance -= 150;
                break;

            case "Tower4(Clone)":
                _balance -= 250;
                break;

            case "Tower5(Clone)":
                _balance -= 500;
                break;

            case "Tower6(Clone)":
                _balance -= 750;
                break;
    }
    }

    public void increaseBalance()
    {
        Debug.Log(FindObjectOfType<MonsterDie>().monsterName);
        
        switch (FindObjectOfType<MonsterDie>().monsterName)
        {
            case "Small Dragon(Clone)":
                _balance += 4;
                break;

            case "Lizard(Clone)":
                _balance += 6;
                break;

            case "Medusa(Clone)":
                _balance += 9;
                break;

            case "Jinn(Clone)":
                _balance += 13;
                break;

            case "Dragon(Clone)":
                _balance += 19;
                break;

            case "Demon(Clone)":
                _balance += 23;
                break;
        }
    }
}
