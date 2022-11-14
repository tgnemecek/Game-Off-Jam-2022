using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField]
  private GameObject pausePanel;
  private bool _isPaused = false;

  void Start()
  {
    pausePanel.SetActive(false);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (_isPaused)
      {
        ResumeGame();
      }
      else
      {
        PauseGame();
      }
    }
  }

  void PauseGame()
  {
    pausePanel.SetActive(true);
    Time.timeScale = 0f;
    _isPaused = true;
  }

  void ResumeGame()
  {
    pausePanel.SetActive(false);
    Time.timeScale = 1f;
    _isPaused = false;
  }

  void GoToMainMenu()
  {
    Time.timeScale = 1f;
    // Todo: We need to add a scene for the Main Menu
    SceneManager.LoadScene("MainMenu");
    _isPaused = false;
  }

  void QuitGame()
  {
    // This only works when the game is built. Not in the editor
    Application.Quit();
  }
}
