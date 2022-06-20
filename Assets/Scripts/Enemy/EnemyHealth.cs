using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    public bool IsDead { get { return isDead; } }

    public void TakeDamage(float damageAmount)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damageAmount;
        
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) { return; }

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
