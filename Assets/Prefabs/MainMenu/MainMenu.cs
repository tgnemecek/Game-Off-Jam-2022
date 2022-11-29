using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
  [SerializeField]
  private float fadeDuration;
  [SerializeField]
  Canvas _howToPlay;
  private List<TextMeshProUGUI> _textsToFade;
  private bool _canClick = false;

  void Awake()
  {
    _textsToFade = new List<TextMeshProUGUI>(GetComponentsInChildren<TextMeshProUGUI>());
  }
  void Start()
  {
    for (int i = 0; i < _textsToFade.Count; i++)
    {
      var text = _textsToFade[i];
      text.color = new Color(
       text.color.r,
       text.color.g,
       text.color.b,
       0f
       );

      var tween = LeanTween.value(text.gameObject, 0f, 1f, fadeDuration)
        .setDelay(1f)
        .setOnUpdate((float value) =>
            {
              text.color = new Color(
              text.color.r,
              text.color.g,
              text.color.b,
              value
              );
            });

      if (i == 0)
      {
        tween.setOnComplete(() =>
        {
          _canClick = true;
        });
      }
    }
  }

  IEnumerator LoadSceneAsync()
  {
    AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/MainScene");
    while (!asyncLoad.isDone)
    {
      yield return null;
    }
  }

  public void StartGame()
  {
    if (!_canClick) return;
    _canClick = false;
    StartCoroutine(LoadSceneAsync());
  }

  public void HowToPlay() => _howToPlay.gameObject.SetActive(true);
  public void QuitGame() => Application.Quit();
}
