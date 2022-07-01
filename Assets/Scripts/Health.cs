using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float healthAmmount = 100;

    private void Update()
    {
        if (healthAmmount <= 0)
        {
            // death restart game 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Healing(10);
        }
    }

    public void TakeDamage(float Damage)
    {
        healthAmmount -= Damage;
        healthBar.fillAmount = healthAmmount / 100;
    }

    public void Healing(float healPoints)
    {
        healthAmmount += healPoints;
        healthAmmount = Mathf.Clamp(healthAmmount, 0, 100);

        healthBar.fillAmount = healthAmmount / 100;
    }
}
