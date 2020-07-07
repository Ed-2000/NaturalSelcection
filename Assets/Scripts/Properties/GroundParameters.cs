using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundParameters : MonoBehaviour
{
    private static float width;    //ширина землі
    private static float length;   //довжина землі

    private void Awake()
    {
        width = GameObject.Find("Ground").transform.localScale.x;
        length = GameObject.Find("Ground").transform.localScale.z;
    }

    public static float Width { get { return width; } }
    public static float Length { get { return length; } }
}
