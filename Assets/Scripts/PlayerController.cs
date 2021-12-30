using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent OnControlOFF;
    public UnityEvent OnControlON;
    static PlayerController Instance;
    public FirstPersonController fpsController;

    private void Awake()
    {
        Instance = this;
    }

    public void SetView(bool to)
    {
        fpsController.cameraCanMove = to;
    }

    public void TurnOffControl()
    {
        OnControlOFF.Invoke();
    }

    public void TurnOnControl()
    {
        OnControlON.Invoke();
    }

    public void MouseControl(bool to)
    {
        if (to)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
