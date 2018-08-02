using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float DamageAmount;

    public GameObject owner;
    public GameObject PS;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != owner && other.GetComponent<BulletController>() == null)
        {
            GameObject TempPS = Instantiate(PS, transform.position, transform.rotation);
            Destroy(TempPS, 3);
            HealthComponent health = other.gameObject.GetComponent<HealthComponent>();
            if(health)
            {
                other.gameObject.GetComponent<HealthComponent>().TakeDamage(DamageAmount);
            }

           

            Destroy(gameObject);
        }
    }
}
