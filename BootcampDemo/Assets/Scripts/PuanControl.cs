using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuanControl : MonoBehaviour
{
    public GameObject Puan;
    List<GameObject> AllPuans = new List<GameObject>();
    TextMesh text;
    public int x=0;
    public GameObject Hero;

    void Awake()
    {
        text = Puan.GetComponentInChildren<TextMesh>();

        for(int i=0;i<10;i++)
        {
            text.text = x.ToString();
            GameObject Puans = Instantiate(Puan,new Vector3(0,-3,335+x),Quaternion.identity);
            AllPuans.Add(Puans);
            x += 50;
        }
        foreach (GameObject x in AllPuans)
        {
            x.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if(Hero.transform.position.z>=290)
        foreach(GameObject x in AllPuans)
        {
            x.SetActive(true);
        }
    }
}
