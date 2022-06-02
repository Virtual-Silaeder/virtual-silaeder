using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public bool active;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Check();
        }
    }
    void Check()
    {
        active = !active;
        if (active)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Unpause()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}