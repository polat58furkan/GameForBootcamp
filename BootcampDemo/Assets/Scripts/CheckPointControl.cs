using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControl : MonoBehaviour
{
    public List<GameObject> CheckPoints = new List<GameObject>();

    public bool once = true;
    void Awake()
    {
        if(CheckPointPlane.levelColor % 4 == 0)
        {
            foreach(GameObject x in CheckPoints)
            {
                x.SetActive(false);
            }
            CheckPoints[0].SetActive(true);
        }

    }
    void FixedUpdate()
    {
        
        if (CheckPointPlane.levelColor % 4 == 1  & once==true)
        {
            once = false;
            foreach (GameObject x in CheckPoints)
            {
                x.SetActive(false);
            }
            CheckPoints[1].SetActive(true);
        }

    }
}
