using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool GameWin = false;
    public static bool GameLose = false;

    public int x;

    //From Canvas
    public GameObject GameWinImage;
    public GameObject GameLoseImage;
    //-----------------


    void Awake()
    {
        GameWin = false;
        GameLose = false;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameLoseImage.SetActive(false);
        GameWinImage.SetActive(false);

    }

    public void RandomScene()
    {
        x = Random.Range(1,4);
        SceneManager.LoadScene(x);
        GameLoseImage.SetActive(false);
        GameWinImage.SetActive(false);

    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
