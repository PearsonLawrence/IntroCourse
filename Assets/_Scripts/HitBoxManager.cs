using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxManager : MonoBehaviour {

    public float DamageAmount = 10;

    public void OnTriggerEnter(Collider other)
    {
        HealthComponent ObjectHealth = other.GetComponent<HealthComponent>();

        if (ObjectHealth != null && other.CompareTag("Player"))
        {
            ObjectHealth.TakeDamage(DamageAmount);
        }
    }

}
