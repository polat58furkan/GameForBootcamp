using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPointPlane : MonoBehaviour
{
    public GameObject CheckPointPlaneObject;
    public GameObject Balls;
    public List<TextMesh> AllText =new List<TextMesh>();

    public static int levelColor = 0;

    void Awake()
    {

        CheckPointPlaneObject.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //When balls number bigger than we need , 
        if(Movement.numberOfBallBoolean==true)
        {
            
            Movement.numberOfBallBoolean = false;

            //Check Point Plane will close and all balls will destroy
            CheckPointPlaneObject.SetActive(true);
            CheckPointPlaneObject.transform.position = Vector3.Lerp(CheckPointPlaneObject.transform.position,new Vector3(0,0, CheckPointPlaneObject.transform.position.z),1f);
            Destroy(Balls);
            //----------------------------------------

            //TextMesh will not seen
            foreach(TextMesh x in AllText)
            {
                x.gameObject.SetActive(false);
            }
            //--------------------------------------

            // Next Movement Control and image color will arrange
            levelColor += 1;
            if(levelColor % 3 ==1)
            {
                Movement.move1 = true;
            }
            if(levelColor % 3 == 2)
            {
                Movement.move2 = true;
                //Touch count reset for the last part of game 
                Movement.TouchCount = 1;
            }
            //----------------------------------------------------------------
            
            //For the new check point plane , some value will reset
            NumberOfObject.number = 0;
            NumberOfObject.once = true;
            NumberOfObject.timerControl = false;
            //-------------------------------------------
        }
        
    }
}
