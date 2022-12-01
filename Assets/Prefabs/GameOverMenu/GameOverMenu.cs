using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
  void OnEnable()
  {
    Time.timeScale = 0f;
  }
  void OnDisable()
  {
    Time.timeScale = 1f;
  }

  public void RestartGame()
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MainScene");
  }

  public void QuitGame()
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MainMenu");
  }
}
