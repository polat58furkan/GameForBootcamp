using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public List<Image> AllImages = new List<Image>();
    public GameObject GameWin;
    public GameObject GameLose;
    public Text  FirstNumber;
    public Text SecondNumber;

    void Awake()
    {
        //GameFinish set
        GameWin.SetActive(false);
        GameLose.SetActive(false);
        //----------------------------------------

        //Color of Canvas image
        AllImages[0].color = Color.cyan;
        AllImages[4].color = Color.cyan;
        for(int i=1;i<4;i++)
        {
            AllImages[i].color = Color.white;
        }
        //-------------------------------------------

        // Level From Signleton 
        FirstNumber.text = Singleton.Instance.GetText();
        SecondNumber.text = (int.Parse(FirstNumber.text)+1).ToString();
        // ------------------------------------
    }

    void FixedUpdate()
    {

        if(GameManager.GameLose==true)
        {
            GameLose.SetActive(true);
            GameManager.GameLose = false;
        }

        if ((CheckPointPlane.levelColor % 4 == 0) & (GameManager.GameWin==true))
        {
            GameManager.GameWin = false;

            GameWin.SetActive(true);

            for (int i = 1; i < 4; i++)
            {
                AllImages[i].color = Color.white;
            }

            Singleton.Instance.SetText(SecondNumber.text);
            PlayerPrefs.SetString("Level", SecondNumber.text);

            FirstNumber.text = Singleton.Instance.GetText();
            SecondNumber.text = (int.Parse(FirstNumber.text) + 1).ToString();
        }

        if (CheckPointPlane.levelColor % 4 == 1)
        {
            AllImages[1].color = Color.cyan;
        }
        if (CheckPointPlane.levelColor % 4 == 2)
        {
            AllImages[2].color = Color.cyan;
        }
        if (CheckPointPlane.levelColor % 4 == 3)
        {
            AllImages[3].color = Color.cyan;
            CheckPointPlane.levelColor += 1;
        }

    }


}
