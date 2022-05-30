using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton instance = null;

    private string text;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("Singleton").AddComponent<Singleton>();

            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;

        //Level save and load system with Signleton
        if(PlayerPrefs.HasKey("Level")==true)
        {
           text= PlayerPrefs.GetString("Level");
        }
        else
        {
            PlayerPrefs.SetString("Level","0");
            text = PlayerPrefs.GetString("Level");
        }
        //-------------------------------
    }

    public string GetText()
    {
        return text;
    }

    public string SetText(string newText)
    {

        return text = newText;

    }

}
