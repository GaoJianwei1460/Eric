using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonView<T> : ViewBase where T : SingletonView<T>
{
    public static T _instance;

    protected virtual void Awake()
    {
        _instance = this as T;
    }

    void Start(){

    }

    void Update(){
        
    }
}
