using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButton 
{
    public KeyCode keyCode;
    public bool Down;
    public bool Up;
    public bool Hold;


    public InputButton(KeyCode keyCode){
        this.keyCode=keyCode;
    }

    public void Get(){
        Down =Input.GetKeyDown(this.keyCode);
        Up =Input.GetKeyUp(this.keyCode);
        Hold =Input.GetKey(this.keyCode);
    }
}
