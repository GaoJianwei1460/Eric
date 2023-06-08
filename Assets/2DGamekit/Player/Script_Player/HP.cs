using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : SingletonView<HP>
{
    public GameObject hp_item_prefab;
    Transform hp_parent;
    GameObject[] hp_items;

    private void Start(){
        hp_parent = transform.Find("hp");
    }

    public void InitHP(int hp){
        hp_items = new GameObject[hp];
        for( int i = 0 ; i< hp ; i++){
            hp_items[i] = GameObject.Instantiate(hp_item_prefab , hp_parent);  
        }
    }

    public void UpdateHP(int hp){
        for(int i = hp ; i < hp_items.Length ; i++){
            if(hp_items[i].GetComponent<Toggle>().isOn){
                hp_items[i].GetComponent<Toggle>().isOn = false;
            }
        }
    }
}
