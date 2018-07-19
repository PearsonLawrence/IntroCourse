using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthComponent : MonoBehaviour {

    public float MaxHealth;
    private float CurrentHealth;

    public float regenSpeed;

    public float DamageTimer;
    private float CurrentDamageTimer;

    public Image HealthBar;
   
    public void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float DamageAmount)
    {
        CurrentHealth -= DamageAmount;
        CurrentDamageTimer = DamageTimer;
        Debug.Log(CurrentHealth);

        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void HealthRegen(float Speed)
    {
        CurrentDamageTimer -= Time.deltaTime;

        if(CurrentDamageTimer <= 0 && CurrentHealth < MaxHealth)
        {
            CurrentHealth += Time.deltaTime * Speed;
           // Debug.Log(CurrentHealth);
        }

        CurrentHealth = (CurrentHealth > MaxHealth) ? MaxHealth : CurrentHealth;
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space)) { TakeDamage(10); }

        HealthRegen(regenSpeed);

        if(HealthBar != null)
        {
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }
	}
}
