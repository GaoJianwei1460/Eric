using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyPad : MonoBehaviour
{
    public Canvas keyPadCanvas;
    public bool isOpen=false;
    public bool canOpen=false;

    void Start(){
        keyPadCanvas.gameObject.SetActive(false);
    }

    void Update(){
        if (canOpen && Input.GetKeyDown(KeyCode.E) ){
            keyPadCanvas.gameObject.SetActive(true);
            isOpen = !isOpen;
        }

        if (isOpen && Input.GetKeyDown(KeyCode.E) ){
            keyPadCanvas.gameObject.SetActive(false);
            isOpen = !isOpen;
        }
    }

    public void OnTriggerEnter2D(Collider2D obj){
       if(obj.CompareTag("Player")){
            keyPadCanvas.gameObject.SetActive(true);
            canOpen = true ;         
        }
    }

     public void OnTriggerExit2D(Collider2D obj){
       if(obj.CompareTag("Player") ){
            keyPadCanvas.gameObject.SetActive(false);
            canOpen = false ;         
        }
    }

}