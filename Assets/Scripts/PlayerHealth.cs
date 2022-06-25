using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageAmount)
    {
        hitPoints -= damageAmount;

        GetComponent<DisplayDamage>().DisplayBloodSplatter();

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<DeathHandler>().HandleDeath();
    }
}
