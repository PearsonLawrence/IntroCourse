using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunController : MonoBehaviour {

    public int Mag;
    public int MaxMag = 20;

    public float FireRate = .1f;

    private float SetFireDelay;
    
    public GameObject bulletPrefab;

    public GameObject ShootPoint;

    public Text AmmoText;

    public float bulletSpeed;
    public void Start()
    {
        Mag = MaxMag;
    }
    public void Fire()
    {
        if(Mag > 0 && SetFireDelay <= 0)
        {
            GameObject TempBullet = Instantiate(bulletPrefab, ShootPoint.transform.position, ShootPoint.transform.rotation);

            TempBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;

            TempBullet.GetComponent<BulletController>().owner = gameObject;

            Destroy(TempBullet, 5);

            SetFireDelay = FireRate;
            Mag--;
        }
    }
	// Update is called once per frame
	void Update () {


        if(AmmoText)
        {
            AmmoText.text = Mag.ToString() + "/" + MaxMag.ToString();
        }

        SetFireDelay -= Time.deltaTime;
	}
}
