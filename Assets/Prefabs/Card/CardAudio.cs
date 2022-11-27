using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAudio : MonoBehaviour
{
  [SerializeField]
  AudioClip _cardClicked;
  [SerializeField]
  AudioClip _cardTouchBoard;
  [SerializeField]
  AudioClip _cardDrawn;
  [SerializeField]
  AudioClip _cardConsumed;
  [SerializeField]
  float _cardConsumedPitchIncreaseRate = 1f;

  private AudioSource _source;

  void Awake()
  {
    _source = GetComponent<AudioSource>();
  }

  public void PlayCardClicked()
  {
    _source.clip = _cardClicked;
    _source.Play();
  }
  public void PlayCardTouchBoard()
  {
    _source.clip = _cardTouchBoard;
    _source.Play();
  }
  public void PlayCardDrawn()
  {
    _source.clip = _cardDrawn;
    _source.Play();
  }

  public void PlayCardConsumed()
  {
    _source.clip = _cardConsumed;
    _source.loop = true;
    _source.Play();
    IEnumerator IncreasePitch()
    {
      while (_source.isPlaying)
      {
        _source.pitch *= _cardConsumedPitchIncreaseRate;
        yield return null;
      }
    }
    StartCoroutine(IncreasePitch());
  }
  public void StopCardConsumed()
  {
    FadeOut();
  }

  void FadeOut(float duration = 0.5f)
  {
    LeanTween
      .value(gameObject, _source.volume, 0f, duration)
      .setOnUpdate((value) => _source.volume = value)
      .setOnComplete(_source.Stop);
  }
}
