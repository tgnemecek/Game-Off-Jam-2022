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
  AudioClip _cardPlayed;
  [SerializeField]
  AudioClip _cardDrawn;
  [SerializeField]
  AudioClip _cardConsumed;
  [SerializeField]
  List<AudioClip> _cardAttackedList;
  [SerializeField]
  float _cardConsumedPitchIncreaseRate = 1f;

  private AudioSource _source;

  void Awake()
  {
    _source = GetComponent<AudioSource>();
  }

  public void PlayCardClicked()
  {
    _source.PlayOneShot(_cardClicked);
  }
  public void PlayCardTouchBoard()
  {
    _source.PlayOneShot(_cardTouchBoard);
  }
  public void PlayCardPlayed()
  {
    if (_cardPlayed != null)
    {
      _source.PlayOneShot(_cardPlayed);
    }
  }
  public void PlayCardDrawn()
  {
    _source.PlayOneShot(_cardDrawn);
  }

  public void PlayCardConsumed()
  {
    _source.clip = _cardConsumed;
    _source.loop = true;
    _source.Play();
    IEnumerator IncreasePitch()
    {
      while (_source.isPlaying && _source.clip == _cardConsumed)
      {
        _source.pitch *= _cardConsumedPitchIncreaseRate;
        yield return null;
      }
      _source.pitch = 1;
    }
    StartCoroutine(IncreasePitch());
  }
  public void StopCardConsumed()
  {
    FadeOut();
  }

  public void PlayCardAttacked()
  {
    int randomIndex = UnityEngine.Random.Range(0, _cardAttackedList.Count - 1);
    _source.PlayOneShot(_cardAttackedList[randomIndex]);
  }

  void FadeOut(float duration = 0.5f)
  {
    float originalVolume = _source.volume;

    LeanTween
      .value(gameObject, _source.volume, 0f, duration)
      .setOnUpdate((value) => _source.volume = value)
      .setOnComplete(() =>
      {
        _source.Stop();
        _source.volume = originalVolume;
      });
  }
}
