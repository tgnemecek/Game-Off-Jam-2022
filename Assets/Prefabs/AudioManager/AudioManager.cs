using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
  [SerializeField]
  AudioSource _source;

  [SerializeField]
  AudioClip _endTurn;

  [SerializeField]
  AudioMixer _mixer;

  [SerializeField]
  AudioMixerSnapshot _defaultSnapshot;

  [SerializeField]
  AudioMixerSnapshot _endOfTurnSnapshot;
  [SerializeField]
  float _endOfTurnTransitionAttack;
  [SerializeField]
  float _endOfTurnTransitionSustain;
  [SerializeField]
  float _endOfTurnTransitionTail;


  private static AudioManager _instance;

  public static AudioManager Instance { get { return _instance; } }

  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
    }
  }

  public void PlayEndTurn()
  {
    _endOfTurnSnapshot.TransitionTo(_endOfTurnTransitionAttack);
    _source.clip = _endTurn;
    _source.Play();

    StartCoroutine(Wait(_endOfTurnTransitionSustain, () =>
    {
      _defaultSnapshot.TransitionTo(_endOfTurnTransitionTail);
    }));
  }

  IEnumerator Wait(float time, Action Callback)
  {
    yield return new WaitForSeconds(time);
    Callback();
  }
}
