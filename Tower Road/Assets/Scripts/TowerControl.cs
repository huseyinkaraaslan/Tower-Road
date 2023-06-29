using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    private Touch finger;
    private Vector3 towerPos;
    private bool dragging;
    private GameObject newTower;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);

            if (finger.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(finger.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Tower")
                {
                    dragging = true;
                    newTower = Instantiate(hit.collider.gameObject);
                    newTower.tag = "Clone Tower";
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
                dragging = false;
            }
        }
    }

}


