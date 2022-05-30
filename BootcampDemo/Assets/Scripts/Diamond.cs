using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour
{
    public static int DiamondNumber;
    public Text text;
    void Awake()
    {
        if(PlayerPrefs.HasKey("Diamond")==true)
        {
            DiamondNumber = PlayerPrefs.GetInt("Diamond");
        }
        else
        {
            PlayerPrefs.SetInt("Diamond",0);
            DiamondNumber= PlayerPrefs.GetInt("Diamond");
        }

        text.text = PlayerPrefs.GetInt("Diamond").ToString();
    }

    void FixedUpdate()
    {
        text.text = PlayerPrefs.GetInt("Diamond").ToString();
    }
}
