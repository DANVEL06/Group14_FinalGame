using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu2 : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu2;

    public void Pause()
    {
        pauseMenu2.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu2.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
