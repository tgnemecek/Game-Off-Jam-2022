using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections.Generic;

public class Core : MonoBehaviour, IHitable
{
  [SerializeField]
  int _maxHP;
  [SerializeField]
  Collider _collider;
  [SerializeField]
  HealthBar _healthBar;
  [SerializeField]
  List<AudioClip> _hitAudios;
  [SerializeField]
  AudioSource _audioSource;

  int _hp;

  void Start()
  {
    _hp = _maxHP;
    _healthBar.Initialize(transform, _maxHP, true);
  }

  public void ReceiveDamage(int damage)
  {
    int randomIndex = UnityEngine.Random.Range(0, _hitAudios.Count - 1);
    _audioSource.PlayOneShot(_hitAudios[randomIndex]);

    _hp -= damage;

    _healthBar.UpdateHealth(_hp);
    ProCamera2DShake.Instance.Shake("Shake_CoreHit");

    if (_hp <= 0)
    {
      _hp = 0;
      GameManager.Instance.GameOver();
    }
  }

  public bool isDead()
  {
    return _hp <= 0;
  }

  public void StartBattle(IHitable hitable) { }

  public Collider GetCollider() => _collider;
  public Transform GetTransform() => transform;
}
