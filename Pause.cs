using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    private void Start()
    {
        if (!isGamePaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    void Update()
    {
        if (!isGamePaused)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

}
