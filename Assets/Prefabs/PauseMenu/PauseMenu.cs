using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  [SerializeField]
  private GameObject _panel;
  private bool _isPaused = false;

  void Start()
  {
    _panel.SetActive(false);
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
    _panel.SetActive(true);
    Time.timeScale = 0f;
    _isPaused = true;
  }

  void ResumeGame()
  {
    _panel.SetActive(false);
    Time.timeScale = 1f;
    _isPaused = false;
  }

  public void GoToMainMenu()
  {
    Time.timeScale = 1f;
    _isPaused = false;
    SceneManager.LoadScene("Scenes/MainMenu");
  }
}
