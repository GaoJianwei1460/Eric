using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
  
    
    public Transform firePos;
    public GameObject bullet; 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U)){
            //if(this.GetComponent<SpriteRenderer>().flipX)   
            Instantiate(bullet,firePos.position,firePos.rotation);
        }
    }
}
