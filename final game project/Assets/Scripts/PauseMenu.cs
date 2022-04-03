using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused =false;
    public GameObject pauseMenuUI;

   
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
        Time.timeScale=1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        isPaused = true;
        Time.timeScale=0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
