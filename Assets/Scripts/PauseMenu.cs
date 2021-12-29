using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    float lastSpeed = 1;
    public UnityEngine.Events.UnityEvent OnPause;
    public UnityEngine.Events.UnityEvent OnUnPause;
    public Animator animator;
    public GameObject menu;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;
            SetPause(isPaused);
        }
    }

    void SetPause(bool to)
    {
        if (to)
        {
            lastSpeed = Time.timeScale;
            Time.timeScale = 0;
            OnPause.Invoke();
        }
        else
        {
            Time.timeScale = lastSpeed;
            OnUnPause.Invoke();
        }
    }

    public void SetEyelids(bool to)
    {
        animator.SetBool("EyesOpen", to);
    }

    public void SetMenuShow(bool to)
    {
        menu.SetActive(to);
        Cursor.visible = to;

        //(to) ? (Cursor.lockState = CursorLockMode.None) : (Cursor.lockState = CursorLockMode.Locked);

        if (to)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowMenu()
    {
        SetMenuShow(true);
    }

    public void HideMenu()
    {
        SetMenuShow(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
