using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager2 : MonoBehaviour
{
    public int damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable2 damageable = collision.gameObject.GetComponent<Damageable2>();
        if (damageable != null)
        {
            damageable.TakeDamage(this.damage);
        }
        else{
            return;
        }
    }

     public void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable2 damageable = collision.gameObject.GetComponent<Damageable2>();
        if (damageable != null)
        {
            damageable.TakeDamage(this.damage);
        }
        else{
            return;
        }
    }


}
