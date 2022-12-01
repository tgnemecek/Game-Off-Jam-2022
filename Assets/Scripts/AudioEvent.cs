using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
  [HideInInspector]
  public int MaxConcurrency = 0;
  [SerializeField]
  List<AudioClip> _clips = new List<AudioClip>();
  //   AudioSource _source;

  int _lastPlayedIndex = -1;

  AudioClip GetClip()
  {
    int randomIndex = UnityEngine.Random.Range(0, _clips.Count);

    if (_lastPlayedIndex == randomIndex)
    {
      randomIndex += 1;
      if (randomIndex >= _clips.Count) randomIndex = 0;
    }

    return _clips[randomIndex];
  }

  public void Play()
  {
    AudioClip clip = GetClip();
    AudioSource.PlayClipAtPoint(clip, transform.position);
  }
}
