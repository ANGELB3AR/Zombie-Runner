using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [Header("Zoom In/Out Distance")]
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;

    [Header("Mouse Sensitivity")]
    [SerializeField] float zoomedInSensitivity = 1f;
    [SerializeField] float zoomedOutSensitivity = 2f;

    RigidbodyFirstPersonController fpsController;
    bool zoomedInToggle = false;

    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }
    
    void ZoomIn()
    {
        mainCamera.fieldOfView = zoomedInFOV;
        zoomedInToggle = true;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    void ZoomOut()
    {
        mainCamera.fieldOfView = zoomedOutFOV;
        zoomedInToggle = false;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
