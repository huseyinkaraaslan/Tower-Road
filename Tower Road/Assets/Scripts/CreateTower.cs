using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    private Touch finger;
    private Vector3 towerPos;

    private bool dragging, isChosedTower;

    public GameObject newTower;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(finger.position), Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject.tag == "Tower")
                {
                    if(hit.collider.gameObject.name == "Tower1" && FindObjectOfType<Balance>()._balance >= 50 ||
                        hit.collider.gameObject.name == "Tower2" && FindObjectOfType<Balance>()._balance >= 100 ||
                        hit.collider.gameObject.name == "Tower3" && FindObjectOfType<Balance>()._balance >= 150 ||
                        hit.collider.gameObject.name == "Tower4" && FindObjectOfType<Balance>()._balance >= 250 ||
                        hit.collider.gameObject.name == "Tower5" && FindObjectOfType<Balance>()._balance >= 500 ||
                        hit.collider.gameObject.name == "Tower6" && FindObjectOfType<Balance>()._balance >= 750)
                    {
                        isChosedTower = true;
                        dragging = true;
                        newTower = Instantiate(hit.collider.gameObject);
                        newTower.tag = "Clone Tower";  // Controlled the movement of the towers visually added under the scene by using a different tag to prevent them from moving.
                    }
                    
                }
            }
            if(finger.phase == TouchPhase.Moved)
            {
                if (dragging)
                {
                    towerPos = Camera.main.ScreenToWorldPoint(finger.position);
                    towerPos.z = 0;
                    newTower.transform.position = towerPos;
                }
            }
            if(finger.phase == TouchPhase.Ended)
            {
                TowerControl isRoadTriggered = newTower.GetComponent<TowerControl>();

                if (isRoadTriggered.isRoadTriggered)
                {
                    Destroy(newTower);
                    isRoadTriggered.isRoadTriggered = false;
                }
                else if(isChosedTower)
                {
                    FindObjectOfType<Balance>().updateBalance(newTower.name);
                }

                isChosedTower = false;
                dragging = false;
            }
        }
    }

    

}


