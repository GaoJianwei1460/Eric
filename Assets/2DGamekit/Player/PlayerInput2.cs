 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput2 : MonoBehaviour
{
    public static PlayerInput2 instance;
    public InputButton Pause=new InputButton(KeyCode.Escape);
    public InputButton Attack=new InputButton(KeyCode.J);
    public InputButton Shoot=new InputButton(KeyCode.K);
    public InputButton Jump=new InputButton(KeyCode.Space);
    
    public InputAxis Horizontal = new InputAxis(KeyCode.A,KeyCode.D);
    public InputAxis Vertical = new InputAxis(KeyCode.S,KeyCode.W);

    private void Awake() 
    {
        if (instance!=null){
            throw new System.Exception("PlayerInput 存在多个对象");
        }
    }

    private void Update(){
        Pause.Get();
        Attack.Get();
        Shoot.Get();
        Jump.Get();
        Horizontal.Get();
        Vertical.Get();
    }
}
