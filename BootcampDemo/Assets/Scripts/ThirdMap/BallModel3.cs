using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModel3 : MonoBehaviour
{
    public GameObject hero;
    public GameObject MainBalls;

    void FixedUpdate()
    {
        if(Mathf.Abs( hero.transform.position.z-this.transform.position.z)<=20)
        {
            float x = 0.5f;
            for(int i=0;i<4;i++)
            {
                GameObject yeni = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                yeni.transform.SetParent(MainBalls.transform);
                yeni.gameObject.tag = "Ball";
                yeni.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                yeni.transform.position = new Vector3(transform.position.x+x*i,0.5f,transform.position.z);
                yeni.GetComponent<MeshRenderer>().material.color = GetComponent<MeshRenderer>().material.color;
                yeni.AddComponent<Rigidbody>();
                yeni.GetComponent<Rigidbody>().useGravity = true;
                yeni.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                yeni.GetComponent<Rigidbody>().mass = 0.01f;

            }
            Destroy(this.gameObject);
        }
    }

}
