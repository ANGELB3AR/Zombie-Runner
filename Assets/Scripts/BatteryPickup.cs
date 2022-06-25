using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float flashlightRestoreAngle = 70f;
    [SerializeField] float flashlightRestoreIntensity = 4f;

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") { return; }

        other.GetComponentInChildren<FlashlightSystem>().RestoreLightAngle(flashlightRestoreAngle);
        other.GetComponentInChildren<FlashlightSystem>().RestoreLightIntensity(flashlightRestoreIntensity);
        Destroy(gameObject);
    }
}
