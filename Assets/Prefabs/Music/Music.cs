using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
  private static Music _instance;

  public static Music Instance { get { return _instance; } }

  AudioSource _source;


  private void Awake()
  {
    if (_instance != null && _instance != this)
    {
      Destroy(this.gameObject);
    }
    else
    {
      _instance = this;
      _source = GetComponent<AudioSource>();
    }
  }

  void Start()
  {
    DontDestroyOnLoad(gameObject);
    _source.Play();
  }
}
