using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount = 5;

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") { return; }

        FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
        Destroy(gameObject);
    }
}
