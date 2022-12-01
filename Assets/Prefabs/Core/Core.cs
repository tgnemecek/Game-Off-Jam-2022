using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections.Generic;
using System;

public class Core : MonoBehaviour, IHitable
{
  [SerializeField]
  int _maxHP; public int MaxHP => _maxHP;
  [SerializeField]
  Collider _collider;
  [SerializeField]
  HealthBar _healthBar;
  [SerializeField]
  List<AudioClip> _hitAudios;
  [SerializeField]
  AudioSource _audioSource;

  private List<Action> _onCoreHit = new List<Action>(); public List<Action> OnCoreHit => _onCoreHit;

  private int _hp;
  public bool Invulnerable = false;

  void Start()
  {
    _hp = _maxHP;
    _healthBar.Initialize(transform, _maxHP, true);
  }

  public void ReceiveDamage(int damage)
  {
    if (Invulnerable) return;

    foreach (var Callback in _onCoreHit)
    {
      Callback();
    }

    int randomIndex = UnityEngine.Random.Range(0, _hitAudios.Count);
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

  public void Heal(int amount)
  {
    _hp += amount;
    if (_hp > _maxHP) _hp = _maxHP;
    _healthBar.UpdateHealth(_hp);
  }

  public bool CanBeTargeted()
  {
    return _hp > 0;
  }

  public Collider GetCollider() => _collider;
  public Transform GetTransform() => transform;
}
