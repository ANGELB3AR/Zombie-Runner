using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas bloodSplatterCanvas;
    [SerializeField] float bloodSplatterEffectTime = 1f;

    public void DisplayBloodSplatter()
    {
        Debug.Log("blood splatter canvaas");
        bloodSplatterCanvas.enabled = true;
    }

    void OnEnable()
    {
        StartCoroutine(BloodSplatterTimer());
    }

    IEnumerator BloodSplatterTimer()
    {
        yield return new WaitForSeconds(bloodSplatterEffectTime);
        bloodSplatterCanvas.enabled = false;
    }
}
