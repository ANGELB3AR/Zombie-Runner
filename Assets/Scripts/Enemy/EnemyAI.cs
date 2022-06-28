using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("General Settings")]
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    [Header("Sound Effects")]
    [SerializeField] AudioSource idleGrowlSFX;
    [SerializeField] AudioSource chaseGrowlSFX;
    [SerializeField] AudioSource attackSFX;
    [SerializeField] AudioSource dieSFX;

    NavMeshAgent navMeshAgent;
    Animator animator;
    EnemyHealth health;
    Transform target;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        target = FindObjectOfType<PlayerHealth>().transform;

        idleGrowlSFX.Play();
    }

    void Update()
    {
        if (health.IsDead) { return; }

        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
    }

    public void OnDamageTaken()
    {
        isProvoked = true;

        if (health.IsDead)
        {
            StopPlayingAudio();
            dieSFX.Play();
            navMeshAgent.enabled = false;
            enabled = false;
            isProvoked = false;
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        chaseGrowlSFX.Play();
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        attackSFX.Play();
        animator.SetBool("attack", true);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void StopPlayingAudio()
    {
        idleGrowlSFX.Stop();
        chaseGrowlSFX.Stop();
        attackSFX.Stop();
    }
}
