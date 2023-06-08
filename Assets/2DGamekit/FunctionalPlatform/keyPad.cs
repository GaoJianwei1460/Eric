using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPad : MonoBehaviour
{
    [SerializeField] private Text Ans;
    [SerializeField] private Animator Door;
    private string Answer="123456";

    public void Number(int number){
        Ans.text +=  number.ToString();
    }

    public void Execute(){
        if(Ans.text == Answer){
            Ans.text = "Correct";
            Door.SetBool("isOpen",true);
        }
        else{
            Ans.text = "Invaid!";
        }
    }

}
