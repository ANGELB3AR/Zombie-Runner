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
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float shootDelayTime = 1f;

    bool readyToShoot = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void OnEnable()
    {
        readyToShoot = true;
    }

    void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo() <= 0 || !readyToShoot) { return; }

        ammoSlot.DecreaseAmmo();
        PlayMuzzleFlash();
        ProcessRaycast();

        readyToShoot = false;
        StartCoroutine(ShootDelay());
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
            CreateImpactEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damagePerHit);
        }
        else return;
    }

    void CreateImpactEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootDelayTime);
        readyToShoot = true;
    }
}
