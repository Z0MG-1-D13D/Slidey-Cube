using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public static bool gameIsPaused = false;

    public GameObject pauseUI;

    public Animator pauseAnim;



    private void Awake()
    {
        pauseUI.SetActive(gameIsPaused);
    }


    public void Resume()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        gameIsPaused = false;
        pauseAnim.SetTrigger("fadeOut");
        pauseAnim.ResetTrigger("fadeIn");
    }

    public void Pause()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else if(!gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseUI.SetActive(true);
            gameIsPaused = true;
            pauseAnim.SetTrigger("fadeIn");
            pauseAnim.ResetTrigger("fadeOut");
        }
    }

    public void LoadMenu()
    {
        Debug.Log("Exiting to Menu...");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Closing Game...");
        Application.Quit();
    }
}
