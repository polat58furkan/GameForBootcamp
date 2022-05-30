using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ball Type",menuName ="Ball Type")]
public class ScriptableBall : ScriptableObject
{
    public Color BallColor = Color.black;
    public Vector3 BallScale = Vector3.one;
    public float mass = 0.01f;
    public string tag = "Ball";
}
