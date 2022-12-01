using UnityEngine;
using UnityEngine.SceneManagement;

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
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void QuitGame()
  {
    SceneManager.LoadScene("Scenes/MainMenu");
  }
}
