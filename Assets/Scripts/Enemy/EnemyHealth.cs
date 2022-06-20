using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

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
        animator.SetTrigger("die");
    }
}
