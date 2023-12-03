using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waipoints : MonoBehaviour
{
    public static Transform[] points;
    void Awake()
    {
        //crea x cantidad de espacios en el array donde x es la cantidad de childs en weypoints
        points = new Transform[transform.childCount];
       
       //loopea por cada child y los inserta en el array
        for (int i=0;i < points.Length; i++)
        {
           points[i] = transform.GetChild(i);
        }
    }


}
