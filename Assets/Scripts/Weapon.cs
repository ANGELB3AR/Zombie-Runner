using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] float fireRange = 100f;
    [SerializeField] float damagePerHit = 30f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, fireRange))
        {
            Debug.Log($"I hit: {hit.transform.name}");
            // TODO: Add some hit effect for visual feedback
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damagePerHit);
        }
        else return;
    }
}
