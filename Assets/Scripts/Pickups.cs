using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") { return; }

        Debug.Log("Picked up");
        Destroy(gameObject);
    }
}
