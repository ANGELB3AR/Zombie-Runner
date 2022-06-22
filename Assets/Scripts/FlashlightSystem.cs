using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light light;

    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLightAngle(float restoreAngle)
    {
        light.spotAngle = restoreAngle;
    }

    public void RestoreLightIntensity(float intensityAmount)
    {
        light.intensity = intensityAmount;
    }

    void DecreaseLightAngle()
    {
        light.spotAngle -= angleDecay * Time.deltaTime;
        Mathf.Clamp(light.spotAngle, minAngle, float.MaxValue);
    }

    void DecreaseLightIntensity()
    {
        light.intensity -= lightDecay * Time.deltaTime;
    }
}
