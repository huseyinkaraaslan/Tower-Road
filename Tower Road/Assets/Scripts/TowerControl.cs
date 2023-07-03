using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{

    [SerializeField] private float targetRange = 2.7f;
    [SerializeField] private LayerMask monsterMask;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    private Transform monster;
    private float timeOfShooting;
    public bool isRoadTriggered;

    private void Update()
    {
        if(monster == null)
        {
            FindMonster();
            return;
        }
        else
        {
            RotateTower();
            if (!(Vector2.Distance(monster.position, this.transform.position) < targetRange))
            {
                monster = null;
            }
            else
            {
                timeOfShooting += Time.deltaTime;

                if(timeOfShooting > .5f){
                    Shoot();
                    timeOfShooting = 0f;
                }
            }
        }        
    }

    private void FindMonster()
    {
        if(this.gameObject.tag != "Tower")
        {
            RaycastHit2D[] monstersHit = Physics2D.CircleCastAll(transform.position, targetRange, transform.position, 0f, monsterMask);

            if (monstersHit.Length > 0)
            {
                monster = monstersHit[0].transform;
            }
        }        
    }

    private void RotateTower()
    {
        float angle = Mathf.Atan2(monster.position.y - this.transform.position.y, monster.position.x - this.transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion _rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        this.transform.rotation = _rotation;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.name = this.gameObject.name;

        Vector2 direction = (monster.position - bullet.transform.position).normalized;
        if(bullet.name == "Tower6(Clone)" || bullet.name == "Tower3(Clone)")
        {
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 25;
        }
        else
        {
            bullet.GetComponent<Rigidbody2D>().velocity = direction * 15;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Road" || collision.gameObject.tag == "Tower")
        {
            isRoadTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Road" || collision.gameObject.tag == "Tower")
        {
            isRoadTriggered = false;
        }
    }
}
