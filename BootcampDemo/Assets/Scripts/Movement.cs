using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Movement : MonoBehaviour
{
    public float x;
    public bool touch=false;

    Rigidbody rb;

    public static bool numberOfBallBoolean=false;
    public static bool move = true;
    public static bool move1 = false;
    public static bool move2 = false;

    public static int TouchCount = 1;

    public static Sequence sequence;

    TextMesh text;

    public bool once = true;

    

    void Awake()
    {
        rb=this.gameObject.GetComponent<Rigidbody>();
        this.transform.position = new Vector3(0,0,-40);
        move = true;
        DOTween.KillAll();
        DOTween.Init();
        sequence = DOTween.Sequence();
    }
    
    void Update()
    {
        // Touch Control
        if(Input.touchCount>0)
        {   
            touch=true;
            Touch finger =Input.GetTouch(0);
            x=finger.deltaPosition.x;

            //For move2 , calculate the touch number;
            if (finger.phase == TouchPhase.Ended)
            {
                TouchCount += 1;
            }
        } 
        //--------------------------------------

    }

    void FixedUpdate()
    {
        // Move To Forward
        
        // Move part1
        if (move == true)
        {
            move = false;
            sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOMoveZ(96, 35));
            sequence.Append(this.transform.DOMoveZ(97.5f,1).SetEase(Ease.OutBounce));
            
        }
        //move part 2
        if(move1 ==true)
        {
            
            move1 = false;
            sequence = DOTween.Sequence();
            sequence.Append(this.transform.DOMoveZ(206, 45));
            sequence.Append(this.transform.DOMoveZ(207.5f, 1).SetEase(Ease.OutBounce));
            
        }

        // Move from hill
        if(move2==true)
        {
            if(this.transform.position.z<=315)
            {
                int y = TouchCount * 2;

                if (y >= 50)
                {
                    y = 50;
                }
                rb.AddForce(new Vector3(0, 0.1f, 0.5f) * y, ForceMode.Acceleration);
                DOTween.KillAll();
            }
            else
            {
                move2 = false;
            }

        }
        //-----------------------------------------------------
        
        // Move to Right-Left
        MoveToRightAndLeft();
    }

    public void MoveToRightAndLeft()
    {
        if (touch==true)
        {
            touch=false;
            rb.AddForce(new Vector3(x,0,0)*5,ForceMode.Acceleration);
            
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Plane")
        {

            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            if(once==true)
            {
                text = collision.gameObject.GetComponentInChildren<TextMesh>();
                Diamond.DiamondNumber += (int.Parse(text.text));
                PlayerPrefs.SetInt("Diamond", Diamond.DiamondNumber);
                CheckPointPlane.levelColor += 1;
                once = false;
                GameManager.GameWin = true;
            }
        }
    }

}
