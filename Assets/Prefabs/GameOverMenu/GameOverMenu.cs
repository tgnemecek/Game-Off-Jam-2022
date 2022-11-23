using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    Hide();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Show()
  {
    this.gameObject.SetActive(true);
    this.enabled = true;
    Time.timeScale = 0f;
  }

  public void Hide()
  {
    this.gameObject.SetActive(false);
    this.enabled = false;
    Time.timeScale = 1f;
  }

  public void RestartGame()
  {
    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
  }

  public void QuitGame()
  {
    // This only works when the game is built. Not in the editor
    Application.Quit();
  }
}
