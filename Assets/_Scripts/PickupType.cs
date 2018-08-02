using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupType : MonoBehaviour {

    public enum Pickup
    {
        Health,
        Shotgun,
        Laser
    }

    public Pickup CurrentPickup;

    private GunController.GunType StoredGunType;

    public float BuffTime, HealAmount;

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
              switch(CurrentPickup)
            {
                case Pickup.Health:
                    other.GetComponent<HealthComponent>().Heal(HealAmount);
                    break;
                case Pickup.Shotgun:
                    other.GetComponent<GunController>().CurrentGun = GunController.GunType.Shotgun;
                    other.GetComponent<GunController>().BuffTime = BuffTime;

                    break;
                case Pickup.Laser:
                    break;
            }
            Destroy(gameObject);
        }
    }
}
