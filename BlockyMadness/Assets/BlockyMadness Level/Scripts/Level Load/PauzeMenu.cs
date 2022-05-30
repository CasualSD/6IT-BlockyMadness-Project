using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeMenu : MonoBehaviour
{
    public GameObject Pauzed;
    public static bool pauzed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauzed)
            {
                Resume();
            }
            else
            {
                Pauze();
            }
        }
    }
    void Resume()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Pauzed.SetActive(false);
        pauzed = false;
    }

    void Pauze()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Pauzed.SetActive(true);
        pauzed = true;
    }
}
