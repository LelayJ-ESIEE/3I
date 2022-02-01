using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentA : MonoBehaviour
{
    private void Awake()
    {
        MyTools.Log(name+" - "+this.GetType().ToString()+" - "+ "Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "Start");

    }

    private void OnEnable()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnEnable");

    }

    private void OnDisable()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnDisable");

    }

    private void OnDestroy()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnDestroy");

    }

    private void OnApplicationPause(bool pause)
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnApplicationPause : " + pause);

    }

    private void OnApplicationQuit()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnApplicationQuit");

    }

    private void OnApplicationFocus(bool focus)
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "OnApplicationFocus");

    }



    // Update is called once per frame
    void Update()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "Update");

    }

    private void FixedUpdate()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "FixedUpdate");

    }

    private void LateUpdate()
    {
        MyTools.Log(name + " - " + this.GetType().ToString() + " - " + "LateUpdate");

    }
}
