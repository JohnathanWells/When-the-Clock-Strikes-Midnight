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
    public Color onTextColor;
    public Color offTextColor;
    public bool lockPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            isPaused = !isPaused;
            SetPause(isPaused);
        }
    }

    public void SneakyPause(bool to)
    {
        if (lockPause)
            return;

        if (to)
        {
            lastSpeed = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = lastSpeed;
        }
    }

    public void SetPause(bool to)
    {
        if (lockPause)
            return;

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

        if (lockPause)
            return;

        menu.SetActive(to);
        Cursor.visible = to;

        //(to) ? (Cursor.lockState = CursorLockMode.None) : (Cursor.lockState = CursorLockMode.Locked);

        if (to)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;

    }

    public void SetMenuShowSneaky(bool to)
    {
        if (lockPause)
            return;

        menu.SetActive(to);
    }

    public void ShowMenu()
    {
        if (lockPause)
            return;

        SetMenuShow(true);
    }

    public void HideMenu()
    {
        if (lockPause)
            return;

        SetMenuShow(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetTextColorOn(TMPro.TextMeshProUGUI text)
    {
        text.color = onTextColor;
    }

    public void SetTextColorOff(TMPro.TextMeshProUGUI text)
    {
        text.color = offTextColor;
    }
}
