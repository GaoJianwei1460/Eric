using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{   
    public float time; 
    GameObject destoryObj;

    void Start(){
        destoryObj=transform.Find("Destructible").gameObject;
        destoryObj.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("DestroyObject", time);
        }
    }

    private void DestroyObject()
    {
        destoryObj.SetActive(true);
        transform.GetComponent<BoxCollider2D>().enabled=false;
        transform.GetComponent<SpriteRenderer>().enabled=false;
        Destroy(gameObject,3);
    }
}
