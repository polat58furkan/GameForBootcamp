using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    [SerializeField] private ScriptableBall ballType = null;

    void Awake()
    {
        GetComponent<Renderer>().material.color = ballType.BallColor;
        transform.localScale = ballType.BallScale;
        this.gameObject.tag = ballType.tag;

        if(GetComponent<Rigidbody>()!=null)
        {
            GetComponent<Rigidbody>().mass = ballType.mass;
        }
        else
        {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().mass = ballType.mass;
        }
    }
}
