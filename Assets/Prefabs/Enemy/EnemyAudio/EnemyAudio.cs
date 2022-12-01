using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
  [SerializeField]
  private AudioSource _source;

  [SerializeField]
  private List<AudioClip> _attackAudios;

  public void PlayAttack()
  {
    int randomIndex = UnityEngine.Random.Range(0, _attackAudios.Count);
    var clip = _attackAudios[randomIndex];
    _source.PlayOneShot(clip);
  }
}
