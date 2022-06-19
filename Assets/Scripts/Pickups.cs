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

        Debug.Log("Picked up");
        Destroy(gameObject);
        FindObjectOfType<Ammo>().IncreaseAmmo(ammoType, ammoAmount);
    }
}
