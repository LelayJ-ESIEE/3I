using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyTools 
{
    public static void Log(string msg)
    {
        Debug.Log(Time.frameCount + " - " + msg);
    }

    public static void ChangeColorRandom(GameObject go)
    {
        MeshRenderer mr = go.GetComponentInChildren<MeshRenderer>();
        if(mr)
        {
            mr.material.color = Random.ColorHSV();
        }
    }
}
