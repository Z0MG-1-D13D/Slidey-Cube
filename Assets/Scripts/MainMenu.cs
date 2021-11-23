using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionsMenu;

    public Button firstSelect;

    private void Awake()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    private void OnEnable()
    {
        firstSelect.Select();
    }

    public void PlayGame()
    {
        //Load the Level Scene
        SceneManager.LoadScene(1);
    }

    public void openOptionsMenu()
    {
        //disable the main menu elements
        mainMenu.SetActive(false);


        //display the options menu
        optionsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenLink(string _url)
    {
        Application.OpenURL(_url);
    }
}
