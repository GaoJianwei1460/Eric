using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable2 : MonoBehaviour
{
    public int health;

    public Action onHurt;
    public Action onDead;

    public void TakeDamage(int damage){
        
        health-=damage;
        if (health==0){
            if(onDead!=null){
                onDead();
            }
        }
        else{
            if(onHurt!=null){
                onHurt();
            }
        }
    }
}
