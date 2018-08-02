using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunController : MonoBehaviour {

    public enum GunType
    {
        Auto,
        Shotgun,
        Laser
    }

    public int Mag;
    public int MaxMag = 20;

    public float FireRate = .1f;

    private float SetFireDelay;
    
    public GameObject bulletPrefab;

    public GameObject[] ShootPoints;

    public Text AmmoText;

    public float bulletSpeed;

    public float BuffTime;

    public GunType CurrentGun = GunType.Auto;

    public void Start()
    {
        Mag = MaxMag;
    }

    public void AutoFire()
    {
        GameObject TempBullet = Instantiate(bulletPrefab, ShootPoints[0].transform.position, ShootPoints[0].transform.rotation);

        TempBullet.GetComponent<Rigidbody>().velocity = ShootPoints[0].transform.forward * bulletSpeed;

        TempBullet.GetComponent<BulletController>().owner = gameObject;

        Destroy(TempBullet, 5);

        SetFireDelay = FireRate;
        Mag--;
    }

    public void ShotGunFire()
    {


        for (int i = 0; i < ShootPoints.Length; i++)
        {
            GameObject TempBullet = Instantiate(bulletPrefab, ShootPoints[i].transform.position, ShootPoints[i].transform.rotation);

            TempBullet.GetComponent<Rigidbody>().velocity = ShootPoints[i].transform.forward * bulletSpeed;

            TempBullet.GetComponent<BulletController>().owner = gameObject;

            Destroy(TempBullet, 5);
        }

        SetFireDelay = FireRate;
        Mag--;
    }

    public void Fire()
    {
        if(Mag > 0 && SetFireDelay <= 0)
        {
            switch(CurrentGun)
            {
                case GunType.Auto:
                    AutoFire();
                    break;
                case GunType.Shotgun:
                    ShotGunFire();
                    break;
            }
        }
    }
	// Update is called once per frame
	void Update () {


        if(AmmoText)
        {
            AmmoText.text = Mag.ToString() + "/" + MaxMag.ToString();
        }

        if (CurrentGun != GunType.Auto) BuffTime -= Time.deltaTime;
        else { CurrentGun = GunType.Auto; }

        SetFireDelay -= Time.deltaTime;
	}
}
