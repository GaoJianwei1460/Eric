using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class FireTrip : MonoBehaviour
{
    public int damageAmount = 1;
    public float repeatRate = 0.5f;
    public ParticleSystem flameParticles;

    private void Start()
    {
        InvokeRepeating("ActivateTrap", 0f, repeatRate);
    }

    private void ActivateTrap()
    {
        flameParticles.Play();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);

        foreach (Collider2D collider in colliders)
        {
            Damageable damageable = collider.GetComponent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(new Damager() { damage = damageAmount }, false);
            }
        }
    }
}