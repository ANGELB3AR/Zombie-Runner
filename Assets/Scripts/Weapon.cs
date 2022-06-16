using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera firstPersonCamera;
    [SerializeField] float fireRange = 100f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(firstPersonCamera.transform.position, firstPersonCamera.transform.forward, out hit, fireRange);
        Debug.Log($"I hit: {hit.transform.name}");
    }
}
