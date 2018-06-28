using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float DamageAmount;

    public GameObject owner;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != owner)
        {
            other.gameObject.GetComponent<HealthComponent>().TakeDamage(DamageAmount);
            Destroy(gameObject);
        }
    }
}
