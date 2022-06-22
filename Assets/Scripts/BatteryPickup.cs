using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float flashlightAngle = 70f;
    [SerializeField] float flashlightIntensity = 4f;

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") { return; }

        other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(flashlightAngle);
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(flashlightIntensity);
        Destroy(gameObject);
    }
}
