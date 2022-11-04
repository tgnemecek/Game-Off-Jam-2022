using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // This variable can be used globally to pause any Update function
    public static bool isPaused=false;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
            {
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale=0f;
        isPaused=true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale=1f;
        isPaused=false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale=1f;
        // Todo: We need to add a scene for the Main Menu
        SceneManager.LoadScene("MainMenu");
        isPaused=false;
    }

    public void QuitGame()
    {
        // This only works when the game is built. Not in the editor
        Application.Quit();
    }
}
