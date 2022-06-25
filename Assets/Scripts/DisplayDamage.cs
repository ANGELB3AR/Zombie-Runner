using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas bloodSplatterCanvas;
    [SerializeField] float bloodSplatterEffectTime = 1f;

    void Start()
    {
        bloodSplatterCanvas.enabled = false;
    }

    public void DisplayBloodSplatter()
    {
        StartCoroutine(BloodSplatterTimer());
    }

    IEnumerator BloodSplatterTimer()
    {
        bloodSplatterCanvas.enabled = true;
        yield return new WaitForSeconds(bloodSplatterEffectTime);
        bloodSplatterCanvas.enabled = false;
    }
}
