using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] Canvas gameWinCanvas;

    void Start()
    {
        gameWinCanvas.enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Player") { return; }

        HandleWin();
    }

    void HandleWin()
    {
        gameWinCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
