using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBase : MonoBehaviour
{
    public void Show(){
        transform.gameObject.SetActive(true);
    } 

    public void Hide(){
        transform.gameObject.SetActive(false);
    }

    public bool IsShow(){
        return gameObject.activeSelf;
    }
}
