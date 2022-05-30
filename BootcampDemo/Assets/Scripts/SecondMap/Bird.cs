using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject bird;
    public GameObject ballPosition;
    public GameObject ball;
    public GameObject mainBalls;
    public float x;
    public float timer,timer2 = 0;


    void FixedUpdate()
    {
        timer += Time.deltaTime * 10;
        x = Mathf.Sin(timer)*2;
        transform.position = Vector3.Lerp(transform.position, transform.position+new Vector3(x,0,1f),0.1f) ;
        
        timer2 += Time.deltaTime;
        if(timer2-1.5f>0)
        {
            timer2 = 0;
            GameObject balls = Instantiate(ball, ballPosition.transform.position, Quaternion.identity);
            balls.transform.SetParent(mainBalls.transform);
        }

        if(transform.position.z>=90)
        {
            Destroy(this.gameObject);
        }
    }
}
