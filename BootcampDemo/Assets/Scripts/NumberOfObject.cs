using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfObject : MonoBehaviour
{
    public List<TextMesh> AllTextMesh = new List<TextMesh>();
    public static int number=0;
    public int requestNumber;

    public static bool once = true;
    public float timer = 0;
    public static bool timerControl = false;
    
    void Awake()
    {
        foreach (TextMesh x in AllTextMesh)
        {
            x.gameObject.SetActive(false);
        }

        AllTextMesh[0].text=number.ToString();
        requestNumber=int.Parse(AllTextMesh[2].text);
    }

    void FixedUpdate()
    {
        
        AllTextMesh[0].text = number.ToString();
        
        if (number >= requestNumber & once==true)
        {
            once = false;
            Movement.numberOfBallBoolean = true;
            requestNumber = int.Parse(AllTextMesh[2].text);
        }

        // Number of Balls control in check time
        if(timerControl==true)
        {
            timer += Time.deltaTime;
        }
        // If there are not enough balls in checkpoint, we will wait 20 sn. After that game is over
        if(timer>20f)
        {
            //Game will finished
            Debug.Log("Finished");
            GameManager.GameLose = true;
        }

    }


    //When the ball touch the check point plane
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Ball")
        {
            foreach (TextMesh x in AllTextMesh)
            {
                x.gameObject.SetActive(true);
            }
            number +=1;
            timer = 0;
            timerControl = true;
        }
    }
}
